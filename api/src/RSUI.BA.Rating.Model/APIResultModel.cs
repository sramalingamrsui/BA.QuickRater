using System.Collections.Generic;
using System.Xml.Serialization;

namespace RSUI.BA.Rating.Model
{
    public class APIResultModel
    {
        public APIResultModel()
        {
            Errors = new List<APIResultMessageModel>();
            Warnings = new List<APIResultMessageModel>();
        }
        public bool SuccessResult { 
            get { return Errors == null || Errors.Count < 1; }
            set { } //ignore set
        }


        public List<APIResultMessageModel> Warnings { get; set; }

        public List<APIResultMessageModel> Errors { get; set; }

        public void AddWarning(int messageCode, string messageText)
        {
            Warnings.Add(new APIResultMessageModel { MessageCode = messageCode, MessageText = messageText});
        }
        public void AddWarning(string messageText)
        {
            Warnings.Add(new APIResultMessageModel { MessageText = messageText });
        }
        public void AddError(int messageCode, string messageText)
        {
            Errors.Add(new APIResultMessageModel { MessageCode = messageCode, MessageText = messageText });

        }
        public void AddError(string messageText)
        {
            Errors.Add(new APIResultMessageModel { MessageText = messageText });

        }
        public void AddError(APIResultMessageModel error)
        {
            Errors.Add(error);
        }
        public void AddWarning(APIResultMessageModel error)
        {
            Warnings.Add(error);
        }
        public void AddErrors(IEnumerable<APIResultMessageModel> errors)
        {
            if (errors != null)
            {
                Errors.AddRange(errors);
            }
        }
        public void AddWarnings(IEnumerable<APIResultMessageModel> warnings)
        {
            if (warnings != null)
            {
                Warnings.AddRange(warnings);
            }
        }
    }
}
