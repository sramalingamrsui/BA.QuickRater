using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class WorksheetSummaryModel
    {
        [JsonProperty(Order = 100)]
        public string QuoteNumber { get; set; }
        [JsonProperty(Order = 200)]
        public string InsuredName { get; set; }
        [JsonProperty(Order = 300)]
        public string Description { get; set; }
        [JsonProperty(Order = 400)]
        public string EffectiveDate { get; set; }
        [JsonProperty(Order = 500)]
        public string ExpirationDate { get; set; }
        [JsonProperty(Order = 600)]
        public string SubmissionNumber { get; set; }
        [JsonProperty(Order = 700)]
        public string CreatedByName { get; set; }
        [JsonProperty(Order = 800)]
        public string CreateDate { get; set; }
        [JsonProperty(Order = 900)]
        public string PrintDate { get; set; }
    }
}
