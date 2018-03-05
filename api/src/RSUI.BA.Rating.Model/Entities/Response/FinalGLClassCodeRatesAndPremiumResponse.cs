using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class FinalGLClassCodeRatesAndPremiumResponse : BaseRatesAndPremiumResponse 
    {


        //PremiumBasis
        public decimal? CreditorSurcharge { get; set; }
        public DateTime? LostCostEffectiveDate { get; set; }
        public DateTime? IncreasedLimitsFactorDate { get; set; }
        public decimal CompanyLostCostMultiplier { get; set; }

        public decimal PremisesDiscretionaryModifier { get; set; }
        public decimal PremisesCombinedModifier { get; set; }
        public string PremisesCombinedModifierRateWorksheetValue { get; set; }
        public decimal? PremisesILFRate { get; set; }
        
        public decimal? PremisesRSUIAdjustedRate { get; set; }
        public decimal? PremisesLostCostRate { get; set; }
        

        public decimal? ProductsDiscretionaryModifier { get; set; }
        public decimal ProductsCombinedModifier { get; set; }
        public string ProductsCombinedModifierWorksheetValue { get; set; }

        public decimal? ProductsILFRate { get; set; }

        public decimal? ProductsFinalRate { get; set; }
        public string ProductsFinalRateWorksheetValue { get; set; }

        public decimal? ProductsRSUIAdjustedRate { get; set; }
        public decimal? ProductsUnmodifiedRate { get; set; }
        public decimal? ProductsPremium { get; set; }
        public string ProductsPremiumWorksheetValue { get; set; }
        public string ProductsAuthorityType { get; set; }

        public decimal TotalPremiumIncludingAdditionalPremium { get; set; }
        public decimal TotalPremiumExcludingAdditionalPremium { get; set; }
        public decimal RatedPremium { get; set; }

        public decimal? AdditionalPremium { get; set; }
        public decimal? AdditionalPremiumWithinMPRequirement { get; set; }
        public decimal? AdditionalPremiumOutsideMPRequirement { get; set; }
        public decimal? CoverageMinimumPremiumOverride { get; set; }

        public bool PremiumIncludesAmountsFromAdditionalQuestions { get; set; }
        public bool ProductsNotCovered { get; set; }

        public bool IsMinimumPremium { get; set; }
        public List<BaseRatesAndPremiumResponse> AdditionalQuestionClassCodeRatesAndPremium { get; set; }

        public decimal? PremisesDiscountFactorFromAdditionalQuestions { get; set; }
        public decimal? ProductsDiscountFactorFromAdditionalQuestions { get; set; }
    }
}

