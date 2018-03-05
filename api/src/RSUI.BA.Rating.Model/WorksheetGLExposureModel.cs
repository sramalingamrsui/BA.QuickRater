using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model
{
    public class WorksheetGLExposureModel
    {
        public string PremisesNumber { get; set; }
        public string ClassCode { get; set; }
        public string Description { get; set; }
        public string Basis { get; set; }
        public string Amount { get; set; }
        
        public string RatePremises { get; set; }
        public string RateProducts { get; set; }
        public string RateOther { get; set; }

        public bool ARateProducts { get; set; }
        public bool ARatePremises { get; set; }
        public bool PureARateProducts { get; set; }
        public bool PureARatePremises { get; set; }
        public string PureARateComments { get; set; }

        public string PremiumPremises { get; set; }
        public string PremiumProducts { get; set; }
        public string PremiumOther { get; set; }
    }
}
