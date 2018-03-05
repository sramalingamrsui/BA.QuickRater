using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RSUI.BA.Rating.Model.Entities.Request;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    [XmlRoot("FinalRatesAndPremiumResponse")]
    public class FinalRatesAndPremiumResponse: BaseRatingResponse
    {
        public decimal TotalPremium { get; set; }
        public FinalPropertyPremiumResponse FinalPropertyPremium { get; set; }
        [XmlElement("FinalGlRatesAndPremium")]
        [JsonProperty(PropertyName = "FinalGlRatesAndPremium",NullValueHandling =NullValueHandling.Ignore)]
        public FinalGLRatesAndPremiumResponse FinalGlRatesAndPremium { get; set; }
        public FinalRateAndPremiumRequest OriginatingRequest { get; set; }

    }
}
