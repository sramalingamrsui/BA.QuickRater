using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class FinalRateAndPremiumPropertyFactors : BasePropertyRequest
    {
        public bool TIVBrokenDownByCoveraeType;
        public decimal BaseRate { get; set; }
        public string Coinsurance { get; set; }
        public string CauseOfLoss { get; set; }
        public string Deductible { get; set; }
        public string Sprinklers { get; set; }
        public string Age { get; set; }
        public bool ExcludeWindHail { get; set; }
        public decimal? WindLoad { get; set; }
        public int? TotalInsuredValue { get; set; }
        public decimal? MinimumPremium { get; set; }

        public string Notes { get; set; }
        public int? BuildingTIV { get; set; }
        public int? BusinessPeronalPropertyTIV { get; set; }
        public int? BusinessIncomeTIV { get; set; }
        public int? OtherTIV { get; set; }

    }
}
