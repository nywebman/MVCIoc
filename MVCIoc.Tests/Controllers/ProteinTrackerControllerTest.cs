﻿using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCIoc.Controllers;
using MVCIoc.Models;

namespace MVCIoc.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void WhenNothingHasHappendTotalAndGoalAreZero()
        {
            ProteinTrackerController controller=new ProteinTrackerController(new StubTrackingService());

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual(0,result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }

        [TestMethod]
        public void WhenTotalIsNonZero_AndAmountAdded_TotalIsIncreased()
        {
            var service = new StubTrackingService();
            service.Total = 10;
            ProteinTrackerController controller = new ProteinTrackerController(service);

            ViewResult result = controller.AddProtein(15) as ViewResult;

            Assert.AreEqual(25, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);   
        }


        public class StubTrackingService : IProteinTrackingService
        {
            public int Total { get; set; }

            public int Goal{ get; set; }
            
            public void AddProtein(int amount)
            {
                Total += amount;
            }
        }

    }
}
