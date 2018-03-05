using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class FinalPropertyPremiumResponse : PropertyRatesResponse
    {
        public decimal FinalRate { get; set; }
        public bool IsMinimumPremium { get; set; }
        public decimal? MinimumPremium { get; set; }
        public decimal PremiumWithinMinimumPremium { get; set; }
        public decimal TotalPremium { get; set; }
        public string TotalPremiumWorkSheetValue { get; set; }
    }
}
