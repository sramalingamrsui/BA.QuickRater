using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Request;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class RatesAndExposureResponse : BaseRatingResponse
    {
        public PropertyRatesResponse PropertyRateResponse { get; set; }
        public GLRatesAndExposuresResponse GlRatesAndExposureResponse { get; set; }
        public RatesAndExposuresRequest OriginatingRequest { get; set; }
    }
}
