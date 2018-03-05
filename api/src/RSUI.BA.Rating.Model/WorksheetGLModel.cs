using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model
{
    public class WorksheetGLModel
    {
        public string AggregateLimit { get; set; }
        public string OccurrenceLimit { get; set; }
        public string ProductAggregateLimit { get; set; }
        public string PersonalAndAdvertisingInjuryLimit { get; set; }
        public string DamagesLimit { get; set; }
        public string MedicalExpenseLimit { get; set; }
        public string Deductible { get; set; }
        public string LossCostModifier { get; set; }
        public List<WorksheetGLExposureModel> GLExposures { get; set; }
    }
}
