using System;
using MVCIoc.Filters;

namespace MVCIoc.Models
{
    public class DebugMessageService : IDebugMessageService
    {
        public string Message {
            get { return DateTime.Now.ToString(); }
        }
    }
}