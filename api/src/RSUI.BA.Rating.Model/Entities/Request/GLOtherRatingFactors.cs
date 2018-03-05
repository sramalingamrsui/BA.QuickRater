using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class GLOtherRatingFactors
    {
        public string ExposureDescription { get; set; }
        public string PremiumBasis { get; set; }
        public int Exposure { get; set; }
        public decimal Rate { get; set; }
        public int Premium { get; set; }
        public RatedBy RatedBy { get; set; }
    }
}
