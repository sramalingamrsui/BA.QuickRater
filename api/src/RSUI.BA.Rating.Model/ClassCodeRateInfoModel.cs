using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class ClassCodeRateInfoModel
    {
        [JsonProperty(Order = 700)]
        public RateInfoModel RateInfo { get; set; }
    }
}
