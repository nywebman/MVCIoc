using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCIoc.Models;
using StructureMap.Attributes;

namespace MVCIoc.Pages
{
    public class ProteinTrackerBasePage :WebViewPage
    {
        [SetterProperty]
        public IAnalyticService AnalyticService { get; set; }

        public override void Execute()
        {
         
        }
    }
}