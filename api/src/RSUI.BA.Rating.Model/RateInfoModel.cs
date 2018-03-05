using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class RateInfoModel
    {
        [JsonProperty(Order = 100)]
        public RatesModel Rates { get; set; }
        [JsonProperty(Order = 200)]
        public ExposureRateInfoModel Exposure { get; set; }
    }
}
