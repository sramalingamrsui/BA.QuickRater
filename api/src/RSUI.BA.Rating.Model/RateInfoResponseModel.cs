using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class RateInfoResponseModel : BaseModel
    {
        [JsonProperty(Order = 500)]
        public GLCoverageModel GlCoverage { get; set; }

        [JsonProperty(Order = 700)]
        public string GeneratedDate { get; set; }
    }
}
