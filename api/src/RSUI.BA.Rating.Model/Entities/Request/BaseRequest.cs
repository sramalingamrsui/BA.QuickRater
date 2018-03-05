using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Location;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class BaseRequest : APIAuthentication
    {
        public string AccountName { get; set; }
        public string RequestedBy { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public LocationFactors LocationInfo { get; set; } 
    }
}
