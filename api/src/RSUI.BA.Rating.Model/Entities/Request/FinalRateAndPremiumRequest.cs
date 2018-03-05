using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    /// <summary>
    /// 
    /// </summary>
    
    public class FinalRateAndPremiumRequest : BaseRequest
    {
        public FinalRateAndPremiumPropertyFactors PropertyFactors { get; set; }
        public FinalRateAndPremiumGLFactors GlFactors { get; set; }
    }
}
