using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCIoc.Models;

namespace MVCIoc.Controllers
{
    public class ProteinTrackerController : Controller
    {
        private ProteinTrackingService proteinTrackingService = new ProteinTrackingService();
        //
        // GET: /ProteinTracker/
        public ActionResult Index()
        {
            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View();
        }

        public ActionResult AddProtein(int amount)
        {
            proteinTrackingService.AddProtein(amount);

            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View("Index");
        }

    }
}
