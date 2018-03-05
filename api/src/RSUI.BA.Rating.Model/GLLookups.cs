using System.Collections.Generic;

namespace RSUI.BA.Rating.Model
{
    public class GLLookUps
    {
        public IEnumerable<string> OccurenceAggregateLimits { get; set; }
        public IEnumerable<string> PRCOLimits { get; set; }
        public IEnumerable<string> PersAndAdvInjuryLimits { get; set; }
        public IEnumerable<string> DamagesToPremisesLimits { get; set; }
        public IEnumerable<string> MedicalExpenseLimits { get; set; }
        public IEnumerable<string> Deductibles { get; set; }
    }
}