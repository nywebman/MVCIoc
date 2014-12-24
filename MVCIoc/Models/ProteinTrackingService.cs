using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIoc.Models
{
    public class ProteinTrackingService 
    {

        public int Total { get; set; }

        public int Goal { get; set; }

        public void AddProtein(int amount)
        {
            Total += amount;
        }

    }
}
