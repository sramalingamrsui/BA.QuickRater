using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class PropertyRatesResponse
    {
        public bool WindLoadEnabled { get; set; }
        public decimal BaseRateRangeLow { get; set; }
        public decimal BaseRateRangeHigh { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public bool IsVacantProperty { get; set; }
    }
}
