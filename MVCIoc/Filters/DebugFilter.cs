using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCIoc.Models;

namespace MVCIoc.Filters
{
    public class DebugFilter : ActionFilterAttribute
    {
        private readonly IDebugMessageService debugMessageService;

        public DebugFilter(IDebugMessageService debugMessageService)
        {
            this.debugMessageService = debugMessageService;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(debugMessageService.Message);
        }
    }
}