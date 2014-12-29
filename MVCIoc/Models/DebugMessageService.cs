using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVCIoc.Models
{
    public class DebugMessageService : IDebugMessageService
    {
        public string Message {
            get { return DateTime.Now.ToString(CultureInfo.InvariantCulture); }
        }
    }
}