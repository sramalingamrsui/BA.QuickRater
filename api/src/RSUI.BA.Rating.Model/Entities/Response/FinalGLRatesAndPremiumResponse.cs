using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class FinalGLRatesAndPremiumResponse
    {
        public string AggregateOccurenceLimits { get; set; }
        public string PRCOLimit { get; set; }
        public string Deductible { get; set; }
        public string PersAndAdvInjuryLimit { get; set; }
        public string DamagesToPremisesLimit { get; set; }
        public string MedicalExpenseLimit { get; set; }

        public decimal TotalPremium { get; set; }
        public string TotalPremiumWorkSheetValue { get; set; }
        public bool IsMinimumPremium { get; set; }
        public decimal? MinPremium { get; set; }
        public decimal? PremiumWithinMPRequirement { get; set; }
        public decimal? PremiumOutsideMPRequirement { get; set; }
        public List<FinalGLClassCodeRatesAndPremiumResponse> ClassCodeRatesAndPremium { get; set; }
    }
}

