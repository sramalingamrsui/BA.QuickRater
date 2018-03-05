using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class GLCoverageModel
    {
        [JsonProperty(Order = 100)]
        public string AggregateOccurrenceLimits { get; set; }
        [JsonProperty(Order = 200)]
        public string PRCOLimit { get; set; }
        [JsonProperty(Order = 300)]
        public string PersAndAdvInjuryLimit { get; set; }
        [JsonProperty(Order = 400)]
        public string DamagesToPremisesLimit { get; set; }
        [JsonProperty(Order = 500)]
        public string MedicalExpenseLimit { get; set; }
        [JsonProperty(Order = 600)]
        public string Deductible { get; set; }
        [JsonProperty(Order = 700)]
        public List<ClassCodeRateModel> ClassCodeSchedule { get; set; }

        [JsonProperty(Order = 800)]
        public GLCoverageRatingResultModel RatingResult { get; set; }
    }
}
