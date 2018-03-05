using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class FinalRateAndPremiumGLFactors
    {
        public string AggregateOccurenceLimits { get; set; }
        public string PRCOLimit { get; set; }
        public string Deductible { get; set; }
        public string PersAndAdvInjuryLimit { get; set; }
        public string DamagesToPremisesLimit { get; set; }
        public string MedicalExpenseLimit { get; set; }

        public List<GLRatingFactors> RatingResponses { get; set; }
        public List<GLOtherRatingFactors> OtherRatingResponses { get; set; }
    }
}

