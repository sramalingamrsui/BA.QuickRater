using System;
using System.Linq;
using RSUI.BA.Rating.Data.Interface;
using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.Data.Validator
{
    public abstract class BaseValidator
    {
        private readonly IDateHelper _dateHelper;
        protected BaseValidator(IDateHelper dateHelper)
        {
            _dateHelper = dateHelper;
        }
        protected APIResultMessageModel ValidateDate(string date, string dateName)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(date, out parsedDate))
            {
                return new APIResultMessageModel { MessageText = string.Format("The {0} date of the policy is invalid", dateName) };
            }
            return null;
        }

        protected APIResultMessageModel ValidateEffectiveAndExpirationDatesDontCross(string effectiveDate, string expirationDate)
        {
            DateTime parsedEffDate;
            DateTime parsedExpDate;
            if (DateTime.TryParse(effectiveDate, out parsedEffDate) && DateTime.TryParse(expirationDate, out parsedExpDate))
            {
                if (parsedExpDate <= parsedEffDate.Date)
                {
                    return new APIResultMessageModel { MessageText = "The effective date of the policy can not be greater than the expiration date" };
                }
            }
            return null;
        }

        protected APIResultMessageModel ValidateGL(GLCoverageModel glCoverage)
        {
            if (glCoverage == null || glCoverage.ClassCodeSchedule == null || !glCoverage.ClassCodeSchedule.Any())
            {
                return new APIResultMessageModel { MessageText = "Either GL coverage model with at least one class in the class code schedule or property coverage model with at least one building in the building schedule must be supplied" };
            }
            return null;
        }
    }
}
