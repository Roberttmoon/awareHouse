using awareHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace awareHouse.Logic
{
    public class Pathfinder
    {
        ApplicationDbContext db = new ApplicationDbContext();



        public Pallet PickLister()
        {
            Pallet palletToPick = new Pallet();

            return palletToPick;
        }

        public async void PickUpPallet(int palletID)
        {
            Pallet truckPalelt = await db.Pallets.FindAsync(palletID);

        }



    }
}