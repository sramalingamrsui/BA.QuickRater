using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class RatesAndExposuresRequest : BaseRequest
    {
        public RatesAndExposuresGLFactors GlFactors { get; set; }
        public RatesAndExposuresPropertyFactors PropertyFactors { get; set; } 
    }
}
