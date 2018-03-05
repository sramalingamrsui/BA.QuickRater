using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model
{
    public class WorksheetGLItemModel
    {
        public string PremisesNumber { get; set; }
        public string ClassCode { get; set; }
        public string RatedBy { get; set; }
        public string Description { get; set; }
        public string Basis { get; set; }
        public string Amount { get; set; }
        public string ModFactorProducts { get; set; }
        public string ModFactorAllOther { get; set; }
        public string RateProducts { get; set; }
        public string RateAllOther { get; set; }
        public string PremiumProducts { get; set; }
        public string PremiumAllOther { get; set; }
    }
}
