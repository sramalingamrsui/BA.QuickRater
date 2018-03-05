using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class RateInfoRequestModel : BaseModel
    {

        [JsonProperty(Order = 600)]
        public GLCoverageModel GlCoverage { get; set; }
    }
}