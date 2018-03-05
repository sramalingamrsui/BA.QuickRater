using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class QuoteSearchModel
    {
        public int? LocationKey { get; set; }
        public int? UnderwriterKey { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string Description { get; set; }   
        public int? CompanyKey { get; set; }
        public int? QuoteNumber { get; set; }
        public string InsuredName { get; set; }
        public string MGAReferenceNumber{get; set; }
        public string HomeState { get; set; }
    }
}
