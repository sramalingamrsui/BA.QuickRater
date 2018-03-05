using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class ExposureCoverageRatingResultModel
    {
        public string LossCostModifier { get; set; }

        [JsonProperty(Order = 100)]
        public string IncreasedLimitsFactor { get; set; }
        [JsonProperty(Order = 200)]
        public string Rate { get; set; }
        [JsonProperty(Order = 300)]
        public string Premium { get; set; }
        [JsonProperty(Order = 400)]
        public string AdjustedRate { get; set; }
    }
}
