using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Shared
{
    public class APIAuthentication
    {
        public string APIIdentifier { get; set; }
        public string User { get; set; }
        public string LoggingCorrelationID { get; set; }
    }
}
