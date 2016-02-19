using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using awareHouse.Models;
using awareHouse.Logic;

namespace awareHouse.Controllers
{
    public class MappingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region selectBuilding
        // GET: Mapping
        public async Task<ActionResult> SelectBuilding()
        {
            int buildingCount = db.Building.Count();
            if (buildingCount < 1)
                return RedirectToAction("CreateBuilding");
            else if (buildingCount == 1)
            {
                Building building = await db.Building.FindAsync(db.Building.First().buildingID);
                // MappingViewModel mvmBuilding = new MappingViewModel { building = building };
                return RedirectToAction("BuildingDetail", new { id = building.buildingID });
            }
            List<Building> buildingList = new List<Building>();
            buildingList = await db.Building.ToListAsync();
            List<MappingViewModel> mvm = new List<MappingViewModel>(buildingList.Count);

            for (int i = 1; i <= buildingList.Count; i++)
            {
                MappingViewModel mapping = new MappingViewModel { building = buildingList[i - 1] };
                mvm.Add(mapping);
            }
            return View(mvm);
        }
        #endregion

        #region Building details
        public async Task<ActionResult> BuildingDetail(int? id)
        {
            Building building;
            if (id == null)
            {
                return RedirectToAction("SelectBuilding");
            }
            building = await db.Building.FindAsync(id);
            List<MappingViewModel> mvmItems = new List<MappingViewModel>();
            List<Row> rows = db.Row.Where(r => r.BuildingID == id).ToList();
            for (int i = 0; i < rows.Count; i++)
            {
                MappingViewModel mapItem = new MappingViewModel { building = building, row = rows[i] };
                mvmItems.Add(mapItem);
            }
            return View(mvmItems);
        }
        #endregion

        #region Create Building

        public ActionResult CreateBuilding()
        {
            return View();
        }

        [HttpPost]
        // POST: CreateBuilding
        public async Task<ActionResult> CreateBuilding(MappingViewModel mvmItem)
        {
            Building building = new Building { buildingName = mvmItem.building.buildingName };
            Dock dock = new Dock { Building = building };
            if (ModelState.IsValid)
            {
                db.Building.Add(building);
                db.Dock.Add(dock);
                await db.SaveChangesAsync();
            }
            for (int i = mvmItem.countHolder; i > 0; i--)
            {
                Row row = new Row { Building = building, rowNumber = i };
                if (ModelState.IsValid)
                {
                    db.Row.Add(row);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("BuildingDetail", new { id = building.buildingID });
        }

        #endregion

        #region Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
               View("SelectBuilding");
            }
            Building building = await db.Building.FindAsync(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            MappingViewModel mapItem = new MappingViewModel { building = building };
            return View(mapItem);
        }

        // POST: MappingView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Building building = await db.Building.FindAsync(id);
            db.Building.Remove(building);
            await db.SaveChangesAsync();
            return RedirectToAction("SelectBuilding");
        }
        #endregion 

        #region Add Bays
        [HttpGet]
        public async Task<ActionResult> AddBays(int? id)
        {
            if (id == null)
                return RedirectToAction("SelectBuilding");
            Row row = await db.Row.FindAsync(id);
            MappingViewModel mvm = new MappingViewModel { row = row };
            return View("AddBays", mvm);
        }

        [HttpPost]
        public async Task<ActionResult> AddBays(int? id, MappingViewModel mvm)
        {
            if (id == null)
                RedirectToAction("SelectBuilding");
            Row row = db.Row.Find(id);
            row.numberOfBays = mvm.row.numberOfBays;
            List<Bay> bays = new List<Bay>();
            for (int i = 0; i < mvm.row.numberOfBays; i++)
            {
                Bay bay = new Bay { bayNumber = i + 1, Row = row };
                if (ModelState.IsValid)
                {
                    db.Bay.Add(bay);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("BuildingDetail", new { id = row.BuildingID });
        }
        #endregion

        #region Bay Mapping
        [Obsolete]
        private List<MappingViewModel> BayMapper(List<Bay> bays)
        {
            List<MappingViewModel> mapReturnItems = new List<MappingViewModel>();
            foreach (Bay bay in bays)
            {
                MappingViewModel map = new MappingViewModel { bays = bay };
                mapReturnItems.Add(map);
            }
            return mapReturnItems;
        }
        [Obsolete]
        private List<Bay> BayMaker(Row row, MappingViewModel mapItem)
        {
            List<Bay> bays = new List<Bay>();
            for (int i = 0; i < mapItem.countHolder; i++)
            {
                Bay bay = new Bay { rowID = row.rowID, bayNumber = i + 1 };
                bays.Add(bay);
            }
            return bays;
        }
        #endregion

        #region Row Detail
        [HttpGet]
        public async  Task<ActionResult> RowDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SelectBuilding");
            }
            Row row = await db.Row.FindAsync(id);
            List<Bay> bays = db.Bay.Where(b => b.rowID == id).ToList();

            if (bays.Count == 0)
                return RedirectToAction("AddBays", new { id = row.rowID });
            
            List<MappingViewModel> mvmItems = RowDetailLogic.BuildBayMap(bays, db);

            return View(mvmItems);
        }
        #endregion

        #region Populate bays
        [HttpGet]
        public async Task<ActionResult> PopulateBays(int? id)
        {
            if (id == null)
                return View("SelectBuilding");
           // Bay bay = await db.Bay.FindAsync(id);
            MappingViewModel mvm = new MappingViewModel { bays = await db.Bay.FindAsync(id) };
            return View(mvm);
        }
        [HttpPost]
        public async Task<ActionResult> PopulateBays(int? id, MappingViewModel mvm)
        {
            if (id == null || mvm == null)
                return View("SelectBuilding");
            PopulateBayLogic pbl = new PopulateBayLogic();
            Bay bay = await db.Bay.FindAsync(id);
            bay.numberOfHeights = mvm.bays.numberOfHeights;
            bay.numberOfSlots = mvm.bays.numberOfSlots;
            mvm.bays = bay;
            List<Height> heights = await pbl.AddHeightsToBay(mvm, db);
            List<Slot> slots = await pbl.AddSlotToHeight(heights, mvm, db);
            return RedirectToAction("RowDetail", new { id = bay.rowID});
        }
        #endregion
    }   
}
