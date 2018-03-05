using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class ClassCodeRatingInputModel
    {
        [JsonProperty(Order = 100)]
        public string AAPremisesRate { get; set; }
        [JsonProperty(Order = 200)]
        public string AAProductsRate { get; set; }

        [JsonProperty(Order = 300)]
        public string QuestionID { get; set; }

        [JsonProperty(Order = 400)]
        public string Answer { get; set; }
        [JsonProperty(Order = 500)]
        public bool ExcludeProducts { get; set; }

        [JsonProperty(Order = 400)]
        public string ARatedComments { get; set; }
    }
}
