using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class ClassCodeRatingResultModel
    {
        [JsonProperty(Order = 100)]
        public string QuestionID { get; set; }
        [JsonProperty(Order = 300)]
        public ExposureCoverageRatingResultModel PremisesCoverageRatingResult;
        [JsonProperty(Order = 400)]
        public ExposureCoverageRatingResultModel ProductsCoverageRatingResult;
        [JsonProperty(Order = 500)]
        public ExposureCoverageRatingResultModel LiquorCoverageRatingResult;
        [JsonProperty(Order = 550)]
        public ExposureCoverageRatingResultModel OCPCoverageRatingResult;
        [JsonProperty(Order = 600)]
        public string Description { get; set; }
        [JsonProperty(Order = 700)]
        public string Answer { get; set; }
        [JsonProperty(Order = 800)]
        public string Basis { get; set; }
        [JsonProperty(Order = 1000)]
        public string TotalPremium { get; set; }
    }
}
