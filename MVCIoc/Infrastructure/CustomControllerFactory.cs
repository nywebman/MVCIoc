using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using MVCIoc.Controllers;
using MVCIoc.Models;

namespace MVCIoc.Infrastructure
{
    public class CustomControllerFactory :IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("proteintracker"))
            {
                var repository = new ProteinRepository();
                var service = new ProteinTrackingService(repository);
                var controller = new ProteinTrackerController(service);
                return controller;
            }

            //Next 2 lines are so we dont break anything that may already exist
            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var dispose = controller as IDisposable;
            if(dispose!=null)
                dispose.Dispose();
        }
    }
}