using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class ClassCodeRateModel
    {
        [JsonProperty(Order = 100)]
        public int PremisesRef { get; set; }
        [JsonProperty(Order = 200)]
        public string Number { get; set; }
		[JsonProperty(Order = 200)]
		public string Subcode { get; set; }
		[JsonProperty(Order = 500)]
        public string Description { get; set; }
        //populated by RateResponse (first response)
        [JsonProperty(Order = 700)]
        public ClassCodeRateInfoModel ClassCodeRateInfo { get; set; }

        [JsonProperty(Order = 800)]
        public ClassCodeRatingInputModel ClassCodeRatingInput { get; set; }
        //populated on second response
        [JsonProperty(Order = 900)]
        public ClassCodeRatingResultModel ClassCodeRatingResult { get; set; }
        [JsonProperty(Order = 900)]
        public string ClassCodeId { get; set; }
        

    }
}
