using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using awareHouse.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace awareHouse.Logic
{
    public class PopulateBayLogic : Controller 
    {
        public async Task<List<Height>> AddHeightsToBay(MappingViewModel mvm, ApplicationDbContext db)
        {
            List<Height> heights = new List<Height>();
            for(int i = 0; i < mvm.bays.numberOfHeights; i++)
            {
                Height height = new Height { heightNumber = i + 1, Bay = mvm.bays };
                if (ModelState.IsValid)
                {
                    db.Height.Add(height);
                    await db.SaveChangesAsync();
                }
                heights.Add(height);
            }
            return heights;
        }
        public async Task<List<Slot>> AddSlotToHeight(List<Height> heights, MappingViewModel mvm, ApplicationDbContext db)
        {
            List<Slot> slots = new List<Slot>();
            foreach(Height h in heights)
            {
                for(int i = 0; i < mvm.bays.numberOfSlots; i++)
                {
                    Slot slot = new Slot { Height = h, slotID = i + 1 };
                    if (ModelState.IsValid)
                    {
                        db.Slot.Add(slot);
                        await db.SaveChangesAsync();
                    }
                    slots.Add(slot);
                }
            }
            return slots;
        }


    }
}