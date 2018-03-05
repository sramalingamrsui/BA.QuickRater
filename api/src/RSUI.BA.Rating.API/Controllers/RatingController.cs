using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac.Features.Indexed;
using log4net;
using NHibernate;
using Newtonsoft.Json;
using NHibernate.Util;
using RSUI.BA.Rating.Data.Interface;
using RSUI.BA.Rating.Data.IoC;
using RSUI.BA.Rating.GL.BizLogic.Interface;
using RSUI.BA.Rating.Model;
using RSUI.Common.Utils.Collection;

namespace RSUI.BA.Rating.API.Controllers
{
	[Authorize(Roles = "Access Mobile App")]
	public class RatingController : ApiController
	{
        private static readonly ILog _log = LogManager.GetLogger(typeof(RatingController));

        private readonly IGLValidator _glValidator;
        private readonly IGLBizLogic _glBizLogic;
        private readonly IGLHelper _glHelper;
        private readonly IGLLookUp _glLookUp;
        private readonly IDateHelper _dateHelper;
        private readonly IRequestModelValidator _requestModelValidator;
        private const string OTHER = "99999";
        //private readonly IRatingBridge _ratingBridge;

        public RatingController(
            //IRatingBridge ratingBridge,
            IGLValidator glValidator,
            IGLHelper glhelper,
            IGLLookUp glLookUp,
            IGLBizLogic glBizLogic,
            IDateHelper dateHelper,
            IRequestModelValidator requestModelValidator,
            IIndex<Databases, ISession> sessions)
        {
            //_ratingBridge = ratingBridge;
            _glValidator = glValidator;
            _glHelper = glhelper;
            _glLookUp = glLookUp;
            _glBizLogic = glBizLogic;
            _dateHelper = dateHelper;
            _requestModelValidator = requestModelValidator;

            // load up the data
            _glHelper.LoadGlTables();
        }

		/// <summary>
		///     Method used to get rates (which includes base rates and ILF for ISO rated class codes), exposures, addtional
		///     questions for GL class codes and the low and high range for rating property
		/// </summary>
		/// <param name="city">City</param>
		/// <param name="state">State</param>
		/// <param name="zipcode">Zipcode</param>
		/// <param name="classcode">Classcode</param>
		/// <param name="subcode">Subcode</param>
		/// <returns>RateInfoResponseModel: Example can be seen by clicking link</returns>
        [Route("api/RateInfoRequest"), HttpGet]
        public HttpResponseMessage RateInfoRequest(string classcode, string subcode, string city = null, string state = null, string zipcode = null)
        {
            var response = new RateInfoResponseModel();
            try
            {
				response.LocationSchedule = new LocationModel[] { GetLocation(city, state, zipcode) };
				response.EffectiveDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
				response.ExpirationDate = DateTime.Now.AddYears(1).Date.ToString("yyyy-MM-dd");
				response.GlCoverage = new GLCoverageModel {
					AggregateOccurrenceLimits = "$1,000,000/$2,000,000",
					ClassCodeSchedule = new List<ClassCodeRateModel> { new ClassCodeRateModel { Number = classcode, Subcode = subcode } }
				};

				GetGLRatesAndExposures(response);

				return Request.CreateResponse(HttpStatusCode.OK, response);
			}
            catch (Exception e)
            {
                _log.Error(e);
                response.APIResult.AddError(new APIResultMessageModel { MessageText = "An internal server error occurred", Exception = e.ToString() });
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
        }

		private string FormatDate(string date)
        {
            DateTime formattedDate;
            if (date != null)
                if (DateTime.TryParse(date, out formattedDate))
                    return formattedDate.ToShortDateString();
            return date;
        }

        private void GetGLRatesAndExposures(RateInfoResponseModel response)
        {
            if (response.GlCoverage != null)
            {
                //get our base rate if we can

                response.GlCoverage.ClassCodeSchedule.Each(cc => cc.ClassCodeRateInfo = new ClassCodeRateInfoModel { });
                _glValidator.ValidateRequest(response, response.APIResult);
                if (response.HasErrors)
                    return;

                var mstClassCodes = _glLookUp.MstClassCodes;
                var filteredClasscodes = response.GlCoverage.ClassCodeSchedule.Where(c => c.Number != OTHER).ToList();
                _glBizLogic.GetClassCodeDetails(filteredClasscodes, response, mstClassCodes);

                foreach (var location in response.LocationSchedule)
                {
                    var isoClasscodes = filteredClasscodes.Where(cc => cc.PremisesRef == location.PremisesNumber).ToList();
                    isoClasscodes.Each(cc => {
							SetISORate(response.GlCoverage.AggregateOccurrenceLimits,
								response.GlCoverage.Deductible, location, cc, response.EffectiveDate);
						}
                    );
                }
            }
        }

        private void SetISORate(string limts, string deductible, LocationModel location, ClassCodeRateModel classCode, string effectiveDate)
        {
            var mstClassCode = _glLookUp.GetMstClassCode(classCode.Number);
            classCode.ClassCodeRateInfo.RateInfo.Rates = _glHelper.GetISORate(limts, deductible, location, mstClassCode, effectiveDate);
        }

		private HttpResponseMessage CallLocationServices(string request)
		{
			var url = ConfigurationManager.AppSettings["LocationService"] + request + "&User=atl30387&APIIdentifier=4221A29C-0268-489A-A352-5F6B57B9F1CB";
			var httpClient = new HttpClient();
			return httpClient.GetAsync(url).Result;
		}

		private LocationModel GetLocation(string city, string state, string zipcode)
		{
			var territory = "";
			if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(state))
			{
				var request = "city/?city=" + city + " " + state;
				var response = CallLocationServices(request);
				if (response.IsSuccessStatusCode)
				{
					var cityResult = JsonConvert.DeserializeObject<CityResultModel>(response.Content.ReadAsStringAsync().Result);
					territory = cityResult.Territories.FirstOrDefault();
				}
			}
			else if (!string.IsNullOrEmpty(zipcode))
			{
				var request = "territory/?zipcode=" + zipcode;
				var response = CallLocationServices(request);
				if (response.IsSuccessStatusCode)
				{
					var territoryResult = JsonConvert.DeserializeObject<TerritoryResponseModel>(response.Content.ReadAsStringAsync().Result).Territories.FirstOrDefault();

					territory = territoryResult?.TerritoryCode;
					state = territoryResult?.TerritoryState;
				}
			}
			return new LocationModel { State = state, City = city, ZipCode = zipcode, TerritoryCode = territory };
		}
	}
}