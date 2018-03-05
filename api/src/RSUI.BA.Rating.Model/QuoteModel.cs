using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class QuoteModel
    {
        public static int DescriptionMaxLen = 250;
        public static int InsuredNameMaxLen = 50;

        [JsonIgnore]
        public bool IsNew { get { return QuoteNumber == null; } }

        //needed for update
        [JsonProperty(Order = 8)]
        public string QuoteNumber { get; set; }
        //provide on insert
        [JsonProperty(Order = 10)]
        public int? SubmissionNo { get; set; }
        [JsonProperty(Order = 15)]
        public int? SubRecordNo { get; set; }
        [JsonProperty(Order = 20)]
        public string Description { get; set; }
        [JsonProperty(Order = 40)]
        public DateTime EffectiveDate { get; set; }
        [JsonProperty(Order = 50)]
        public DateTime ExpirationDate { get; set; }
        [JsonProperty(Order = 1000)]
        public string RatingResult { get; set; }
        [JsonProperty(Order = 100)]
        public string InsuredName { get; set; }
        [JsonProperty(Order = 100)]
        public string InsuredCity { get; set; }
        [JsonProperty(Order = 100)]
        public string InsuredState { get; set; }
        [JsonProperty(Order = 140)]
        public DateTime CreateDate { get; set; }
        [JsonProperty(Order = 160)]
        public int? CreatedByEmpRecNbr { get; set; }
        [JsonProperty(Order = 170)]
        public string CreatedBy { get; set; }
        [JsonProperty(Order = 180)]
        public DateTime LastModifiedDate { get; set; }
        [JsonProperty(Order = 200)]
        public int? LastModifiedEmpRecNbr { get; set; }
        [JsonProperty(Order = 210)]
        public string LastModfiedBy { get; set; }
        [JsonProperty(Order = 240)]
        public DateTime? GeneratedDate { get; set; }
    }
}
