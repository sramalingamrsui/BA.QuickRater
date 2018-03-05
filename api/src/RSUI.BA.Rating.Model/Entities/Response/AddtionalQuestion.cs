using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class AddtionalQuestion : GLRatingExposure
    {
        public string AssociatedClassCode { get; set; }
        public string Notes { get; set; }
        public string AdditionalCharge { get; set; }
        public string AdditionalChargeBasis { get; set; }
        public bool PremiumWithinMinimumPremiumRequirements { get; set; }
        public bool Mandatory { get; set; }
    }
}
