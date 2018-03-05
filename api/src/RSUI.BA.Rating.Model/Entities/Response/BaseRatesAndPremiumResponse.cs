using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class BaseRatesAndPremiumResponse:ClassCodeBase 
    {
        public string ExposureDescription { get; set; }
        public string ExposureValue { get; set; }
        public int? ExposureID { get; set; }

        public decimal? PremisesPremium { get; set; }
        public string PremisesPremiumWorksheetValue { get; set; }

        public string PremisesAuthorityType { get; set; }

        public decimal? PremisesFinalRate { get; set; }
        
        public string PremisesFinalRateWorksheetValue { get; set; }

        public string ExposureBasis { get; set; }

        public RatedBy RatedBy { get; set; }

        public bool PremiumWithinMinimumPremiumRequirements { get; set; }

        public string RatedByString
        {
            get {
                return RatedBy == RatedBy.IfAny ? "If Any" : RatedBy.ToString();
            }
        }
    }
}
