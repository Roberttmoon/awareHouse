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
    public class MappingViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mapping
        public async Task<ActionResult> Index()
        {
            if (!db.Building.Any())
            {
                return RedirectToAction("CreateBuilding");
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

        // GET: Mapping/Create
        public ActionResult CreateBuilding()
        {
            return View();
        }

        // POST: Mapping/CreateBuilding
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBuilding(MappingViewModel newBuilding)
        {
            Building building = new Building { buildingName = newBuilding.building.buildingName };
            if (ModelState.IsValid)
            {
                db.Building.Add(building);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(building);
        }

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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            return RedirectToAction("Index");
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
            if (id == null)
            {
                return View("Index");
            }
            List<MappingViewModel> mvmItems = new List<MappingViewModel>();
            Building building = await db.Building.FindAsync(id);
            List<Row> rows = db.Row.Where(r => r.BuildingID == id).ToList();
            if (rows.Count == 0)
            {
                return RedirectToAction("CreateRow", new { id = id });
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRow(int? id, MappingViewModel mapItem)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Row row = new Row { BuildingID = (int)id, rowNumber = mapItem.row.rowNumber };
            if (ModelState.IsValid)
            {
                db.Row.Add(row);
                await db.SaveChangesAsync();
            }
            List<Bay> bays = BayMaker(row, mapItem);
            foreach (Bay b in bays)
            {
                if (ModelState.IsValid)
                {
                    db.Bay.Add(b);
                    await db.SaveChangesAsync();
                }
            }
            List<MappingViewModel> mapReturnItems = BayMapper(bays);
            return View("Index", mapReturnItems);
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
            for (int i = 0; i < mapItem.stupidHolderTHingy; i++)
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
