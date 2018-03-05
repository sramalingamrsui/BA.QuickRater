using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class ExposureRateInfoModel
    {
        [JsonProperty(Order = 100)]
        public string ExposureDataType { get; set; }
        [JsonProperty(Order = 200)]
        public string ExposureDivisor { get; set; }

        [JsonProperty(Order = 300)]
        public string ExposureBasis { get; set; }
        [JsonProperty(Order = 400)]
        public string Question { get; set; }
        [JsonProperty(Order = 500)]
        public string QuestionID { get; set; }
    }
}
