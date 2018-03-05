using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.Data.Interface;
using RSUI.BA.Rating.GL.BizLogic.DTO;
using RSUI.BA.Rating.GL.BizLogic.Interface;
using RSUI.BA.Rating.Model;
using RSUI.Common.Utils.Collection;

namespace RSUI.BA.Rating.GL.BizLogic.Impl
{
    public class GLValidator : IGLValidator
    {
        private readonly IGLLookUp _glLookUp;
        private readonly IGLHelper _glHelper;
        private const string OTHER = "99999";
        private const string ADDINS = "49950";
        private const string EBL = "92100";
        private readonly string[] _nonLocationDrivenClassCodes = { OTHER, ADDINS, EBL };
        private const decimal discretionaryModifierLowerLimitPre1212014ISO = .75m;
        private const decimal discretionaryModifierLowerLimitISO = .85m;
        private const decimal discretionaryModifierLowerLimitCompany = 1m;
        private const string MANDATORY = "M";
        private const string OPTIONAL = "C";
        private const string CHOOSE_ONE = "R";

        private readonly IDateHelper _dateHelper;
        public GLValidator(IGLLookUp glLookUp, IGLHelper glHelper, IDateHelper dateHelper)
        {
            _glLookUp = glLookUp;
            _glHelper = glHelper;
            _dateHelper = dateHelper;
        }

        public void ValidateRequest(RateInfoResponseModel rateInfoRequest, APIResultModel apiResult)
        {
            apiResult.AddErrors(ValidateLocations(rateInfoRequest.LocationSchedule, rateInfoRequest.GlCoverage));
            var limitErr = ValidateValueIsNotEmptyAndIsValidFromList(
                rateInfoRequest.GlCoverage.AggregateOccurrenceLimits, _glLookUp.OccurenceAggregateLimits, "Occurence/Aggregate Limit");
            if (limitErr != null)
                apiResult.AddError(limitErr);

            if (rateInfoRequest.GlCoverage.ClassCodeSchedule == null || !rateInfoRequest.GlCoverage.ClassCodeSchedule.Any())
            {
                apiResult.AddError(new APIResultMessageModel { MessageText = "You must supply at least one GL class code" });
            }
            apiResult.AddErrors(ValidateClassCodes(rateInfoRequest.GlCoverage));
        }
        #region common validations

        private IEnumerable<APIResultMessageModel> ValidateClassCodes(GLCoverageModel gLCoverage)
        {
            var results = new List<APIResultMessageModel>();
            var classCodes = gLCoverage.ClassCodeSchedule.Where(cc => cc.Number != OTHER).DistinctBy(cc => new { cc.Number });
            
            classCodes.Each(cc =>
            {
                var genericMsg = string.Format("Class code {0} had the following error:", cc.Number);
                var mstClassCode = _glLookUp.GetMstClassCode(cc.Number);
                if (mstClassCode == null)
                {
                    results.Add(new APIResultMessageModel { MessageText = string.Format("{0} Invalid or Inactive ClassCode[{1}] or RSUI not rating for this ClassCode[{0}].", genericMsg, cc.Number) });
                }
            });
            return results;
        }

        protected IEnumerable<APIResultMessageModel> ValidateLocations(IEnumerable<LocationModel> locations, GLCoverageModel glCoverage)
        {
            var results = new List<APIResultMessageModel>();
            //validate all gllocations referenced in class codes exist in LocationSchedule
            foreach (var classCode in glCoverage.ClassCodeSchedule)
            {
                if (!locations.Any(location => location.PremisesNumber == classCode.PremisesRef))
                {
                    results.Add(new APIResultMessageModel
                    {
                        MessageText = string.Format("ClassCode {0} Location {1} does not have a matching location.",
                            classCode.Number,
                            classCode.PremisesRef)
                    });
                }
            }
            return results;
        }

        protected APIResultMessageModel ValidateDeductible(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return new APIResultMessageModel { MessageText = "The deductible must be supplied in order to rate GL" };
            }
            var list = _glLookUp.Deductibles;

            if (!list.Contains(val))
            {
                return new APIResultMessageModel { MessageText = string.Format("The value supplied for the dedutible ({0}) is not a valid value.  The following items are valid({1})", val, ParseList(list)) };
            }
            return null;
        }

        #endregion common validations.

        #region support functions
        private APIResultMessageModel ValidateValueIsNotEmptyAndIsValidFromList(string val, IEnumerable<string> validValues, string name)
        {

            if (string.IsNullOrWhiteSpace(val))
            {
                return new APIResultMessageModel { MessageText = string.Format("The {0} must be supplied in order to get a final GL rate", name) };
            }

            var enumerable = validValues as string[] ?? validValues.ToArray();
            if (!enumerable.Contains(val))
            {
                return new APIResultMessageModel { MessageText = string.Format("The value supplied for {0} ({1}) is not a valid value.  The following items are valid({2})", name, val, ParseList(enumerable)) };
            }
            return null;
        }

        private string ParseList(IEnumerable<string> list)
        {
            var parsedList = new StringBuilder();

            list.Each(listItem => parsedList.Append(parsedList.Length != 0 ? ", " + listItem : listItem));

            return parsedList.ToString();
        }

        private bool AnswerIsNumeric(string answer)
        {
            double d;
            if (!double.TryParse(answer, out d))
            {
                return false;
            }
            return true;
        }
        #endregion support functions
    }
}
