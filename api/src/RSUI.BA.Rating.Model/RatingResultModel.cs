using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    [XmlRoot("RatingResult")]
    public class RatingResultModel : BaseModel
    {
        [JsonProperty(Order = 100)]
        public GLCoverageModel GlCoverage { get; set; }
        [JsonProperty(Order = 700)]
        public string GeneratedDate { get; set; }
    }
}
