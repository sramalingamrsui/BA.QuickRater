using System.Collections.Generic;
using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.GL.BizLogic.Interface
{
    public interface IGLValidator
    {
        void ValidateRequest(RateInfoResponseModel rateInfoRequest, APIResultModel apiResult);
    }
}
