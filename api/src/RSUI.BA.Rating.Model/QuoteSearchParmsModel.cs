using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class QuoteSearchParmsModel
    {
        public string CreatedBy { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string Description { get; set; }   
        public string QuoteNumber { get; set; }
        public string InsuredName { get; set; }
        public string MGAReferenceNumber{get; set; }
    }
}
