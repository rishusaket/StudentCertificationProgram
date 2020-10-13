using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptionLogger
{
    public class ExceptionLogger
    {
        public int ExceptionId { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExceptionStackTrack { get; set; }
        public DateTime ExceptionLogTime { get; set; }
    }
}
