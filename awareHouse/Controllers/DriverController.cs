using awareHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace awareHouse.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlacePallet(DriverViewModel dvm)
        {
            if (dvm == null)
                return Index();

            return View("index", dvm);
        }

        public ActionResult PickPallet(DriverViewModel dvm)
        {
            if (dvm == null)
                return Index();
            return View("index", dvm);
        }
    }
}