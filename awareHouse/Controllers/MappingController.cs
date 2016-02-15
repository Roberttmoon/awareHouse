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

namespace awareHouse.Controllers
{
    public class MappingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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
                MappingViewModel mvmBuilding = new MappingViewModel { building = building };
                return RedirectToAction("BuildingDetail", mvmBuilding);
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
        public ActionResult CreateBuilding()
        {
            return View();
        }

        #region Create Building

        [HttpPost]
        // POST: CreateBuilding
        public async Task<ActionResult> CreateBuilding(MappingViewModel mvmItem)
        {
            Building building = new Building { buildingName = mvmItem.building.buildingName };
            if (ModelState.IsValid)
            {
                db.Building.Add(building);
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
            return View("BuildingDetail");
        }

        #endregion
        // GET: Mapping/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    List<Row> rows = db.Row.Where(r => r.buildingFK == id).ToList();
        //    // await Task.WaitAll(rows);
        //    if (rows == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(rows);
        //}

        //// GET: Employees/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Building building = await db.Building.FindAsync(id);
        //    if (building == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(building);
        //}

        //// POST: Employees/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "buildingName")] Building building)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(building).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(building);
        //}

        // GET: Employees/Delete/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
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
        [HttpGet]
        public ActionResult CreateRow(int? id)
        {
            return View("CreateRow");
        }

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

        [HttpGet]
        public async  Task<ActionResult> RowDetail(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            List<MappingViewModel> mvmItems = new List<MappingViewModel>();
            Row row = await db.Row.FindAsync(id);
            List<Bay> bays = db.Bay.Where(b => b.rowID == id).ToList();

            if (bays.Count == 0)
                return View("Index");

            for (int i = 0; i < bays.Count; i++)
            {
                MappingViewModel mapped = new MappingViewModel { bays = bays[i] };
                mvmItems.Add(mapped);
            }

            return View(mvmItems);
        }
        [HttpPost]
        public async Task<ActionResult> RowDetail(int? id, List<MappingViewModel> mapedItems)
        {
            if (id == null)
            {
                return View("Index");
            }



            return View("Index");
        }
    }   
}
