using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCIoc.Models;

namespace MVCIoc.Pages
{
    public class ProteinTrackerBasePage :WebViewPage
    {
        public IAnalyticService AnalyticService { get; set; }

        //need parameterless contructor

        public override void Execute()
        {
         
        }
    }
}