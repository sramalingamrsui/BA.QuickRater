using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            APIResult = new APIResultModel();
        }

        //[JsonProperty(Order = 100)]
        //public APIAuthenticationModel APIAuthentication { get; set; }

        [JsonProperty(Order = 150)]
        public APIResultModel APIResult { get; set; }

        [JsonIgnore]
        public bool HasErrors
        {
            get { return APIResult != null && (APIResult.Errors != null && APIResult.Errors.Count > 0); }
            set { } //ignore set
        }

        public void AddErrors(IEnumerable<APIResultMessageModel> errors)
        {
            APIResult.Errors.AddRange(errors);
        }
        public void AddWarnings(IEnumerable<APIResultMessageModel> warnings)
        {
            APIResult.Warnings.AddRange(warnings);
        }
        [JsonProperty(Order = 200)]
        public string EffectiveDate { get; set; }
        [JsonProperty(Order = 250)]
        public string ExpirationDate { get; set; }

        [JsonProperty(Order = 300)]
        public IEnumerable<LocationModel> LocationSchedule { get; set; }

    }
}
