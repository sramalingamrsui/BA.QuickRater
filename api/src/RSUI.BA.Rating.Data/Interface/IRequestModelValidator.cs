
using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.Data.Interface
{
    public interface IRequestModelValidator
    {
        void ValidateRequest(RateInfoRequestModel rateInfoRequest, APIResultModel apiResult);

    }
}
