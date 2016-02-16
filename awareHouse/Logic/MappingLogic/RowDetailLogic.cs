using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using awareHouse.Models;

namespace awareHouse.Logic
{
    public class RowDetailLogic
    {
        
        public static List<MappingViewModel> BuildBayMap(List<Bay> bays, ApplicationDbContext db)
        {
            List<MappingViewModel> mvmItems = new List<MappingViewModel>();
            foreach (Bay bay in bays)
            {
                List<Slot> slotCount = db.Slot.Where(s => s.heightID == db.Height.Where(h => h.BayID == bay.bayID).FirstOrDefault().heightID).ToList();
                List<Height> heightCount = db.Height.Where(h => h.BayID == bay.bayID).ToList();
                bay.numberOfHeights = heightCount.Count();
                bay.numberOfSlots = slotCount.Count();
                MappingViewModel mapped = new MappingViewModel { bays = bay };
               // mapped.bays.numberOfHeights = heightCount.Count();
               // mapped.bays.numberOfSlots = slotCount.Count();
                mvmItems.Add(mapped);
            }
            return mvmItems;
        }
    }
}