using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class ClassCodeExposureRateInfo
    {
        public int ID { get; set; }
        public string Answer { get; set; }
        public string Description { get; set; }
        public string AuthorityType { get; set; }
        public ExposureRateAndPremiumInfo PremisesPremium { get; set; }
        public ExposureRateAndPremiumInfo ProductsPremium { get; set; }
    }
}
