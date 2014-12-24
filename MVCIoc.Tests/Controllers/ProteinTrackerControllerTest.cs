using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCIoc.Controllers;

namespace MVCIoc.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void WhenNothingHasHappendTotalAndGoalAreZero()
        {
            ProteinTrackerController controller=new ProteinTrackerController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual(0,result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }
    }
}
