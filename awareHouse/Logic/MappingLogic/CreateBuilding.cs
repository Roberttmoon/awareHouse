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

namespace awareHouse.Logic
{
    public class CreateBuilding : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public async void MakeBuilding(MappingViewModel mvmBuilding)
        {
            Building building = new Building { buildingName = mvmBuilding.building.buildingName };
            if (ModelState.IsValid)
            {
                db.Building.Add(building);
                await db.SaveChangesAsync();
            }
            AddRowsToBuilding(mvmBuilding, building);
        }
        private async void AddRowsToBuilding(MappingViewModel mvmCount, Building building)
        {
            for (int i = mvmCount.countHolder; i > 0; i--)
            {
                Row row = new Row { Building = building };
                if (ModelState.IsValid)
                {
                    db.Row.Add(row);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}