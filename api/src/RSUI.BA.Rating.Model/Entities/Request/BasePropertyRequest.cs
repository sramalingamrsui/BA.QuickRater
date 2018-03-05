using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class BasePropertyRequest
    {

        public string Construction { get; set; }
        public string OccupancyType { get; set; }
        public string ProtectionClass { get; set; }
        public string ValuationBasis { get; set; }
    }
}
