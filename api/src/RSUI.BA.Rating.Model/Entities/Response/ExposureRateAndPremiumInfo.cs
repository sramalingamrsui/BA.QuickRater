using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class ExposureRateAndPremiumInfo
    {
        public decimal? LostCostFactor { get; set; }
        public decimal? IncreasedLimitsFactor { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Premium { get; set; }
        public decimal? PreAdjustedRate { get; set; }
        public decimal? UnmodifiedRate { get; set; }
    }
}
