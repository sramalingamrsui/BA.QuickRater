using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class QuoteViewModel
    {
        [XmlIgnore]
        [JsonIgnore]
        public int QuoteID { get; set; }
        public int QuoteNumber { get; set; }
        public int? CompanyKey { get; set; }
        //public string CompanyPrefix { get; set; }
        public string MGAReferenceNumber { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? LocationKey { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatedByPeopleKey { get; set; }
        public int? CreatedByEmpRecNbr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int? LastModifiedByPeopleKey { get; set; }
        public int? LastModifiedEmpRecNbr { get; set; }
        public string LastModfiedBy { get; set; }
        public DateTime? LastPrintDate { get; set; }
        public RatingResponseModel LastRatingResponseModel { get; set; }
        public string FormattedQuoteNumber { get; set; }
        public int? UnderwriterPeopleKey { get; set; }
        public string Underwriter { get; set; }
        public string HomeState { get; set; }
        public string InsuredName { get; set; } 
    }
}
