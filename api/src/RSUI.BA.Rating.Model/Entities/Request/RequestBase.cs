using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class RequestBase : APIAuthentication
    {
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Address  Location { get; set; }
    }
}
