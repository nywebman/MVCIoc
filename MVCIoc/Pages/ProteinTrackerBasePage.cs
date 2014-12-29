using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MVCIoc.Models;

namespace MVCIoc.Pages
{
    public class ProteinTrackerBasePage :WebViewPage
    {
        [Dependency]
        public IAnalyticService AnalyticService { get; set; }

        //need parameterless contructor

        public override void Execute()
        {
         
        }
    }
}