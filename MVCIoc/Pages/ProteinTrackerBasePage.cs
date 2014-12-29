using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCIoc.Models;
using Ninject;

namespace MVCIoc.Pages
{
    public class ProteinTrackerBasePage :WebViewPage
    {
        [Inject]
        public IAnalyticService AnalyticService { get; set; }

        public override void Execute()
        {
         
        }
    }
}