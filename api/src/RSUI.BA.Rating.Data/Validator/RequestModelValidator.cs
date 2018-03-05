
using RSUI.BA.Rating.Data.Interface;
using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.Data.Validator
{
    public class RequestModelValidator : BaseValidator, IRequestModelValidator
    {
        public RequestModelValidator(IDateHelper dateHelper) : base(dateHelper)
        {
        }
        public void ValidateRequest(RateInfoRequestModel rateInfoRequest, APIResultModel apiResult)
        {
            var dateErr = ValidateDate(rateInfoRequest.EffectiveDate, "effective");
            if (dateErr != null)
                apiResult.AddError(dateErr);
            dateErr = ValidateDate(rateInfoRequest.ExpirationDate, "expiration");
            if (dateErr != null)
                apiResult.AddError(dateErr);
            dateErr = ValidateEffectiveAndExpirationDatesDontCross(rateInfoRequest.EffectiveDate, rateInfoRequest.ExpirationDate);
            if (dateErr != null)
                apiResult.AddError(dateErr);
            var covModelErr = ValidateGL(rateInfoRequest.GlCoverage);
            if (covModelErr != null)
                apiResult.AddError(covModelErr);
        }
    }
}
