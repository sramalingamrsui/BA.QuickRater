using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using Autofac.Features.Indexed;
using FluentNHibernate.Conventions.Inspections;
using log4net;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Linq;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.Data.Hash;
using RSUI.BA.Rating.Data.Interface;
using RSUI.BA.Rating.Data.IoC;
using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.Data.Validator 
{
    public class QuoteModelValidator : IQuoteModelValidator
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(QuoteModelValidator));

        private readonly IIndex<Databases, ISession> _sessions;
        private readonly IDateHelper _dateHelper;
        private static string WEBSUFFIX = "-web";
        public QuoteModelValidator(IIndex<Databases, ISession> sessions, IDateHelper dateHelper)
        {
            _sessions = sessions;
            _dateHelper = dateHelper;
        }
        protected ISession RSUIDBSession { get { return _sessions[Databases.RSUI]; } }
        public void ValidateQuoteModel(QuoteModel quoteModel, APIResultModel apiResult, APIUser currentUser)
        {
            apiResult.AddErrors(VerifyQuoteDates(quoteModel));

            //now we need to see if the user can actually save the quotedata (hashed properly)
            apiResult.AddErrors(ValidateUserCanSaveQuoteData(quoteModel, currentUser));
        }

        private IEnumerable<APIResultMessageModel> ValidateUserCanSaveQuoteData(QuoteModel quoteModel, APIUser currentUser)
        {
            var submission = RSUIDBSession.Query<Submission>().FirstOrDefault(s => s.SubRecNbr == quoteModel.SubRecordNo);

            var errorList = new List<APIResultMessageModel>();
            if (quoteModel.SubRecordNo != null && currentUser.EmpProfitCenter != submission?.Department.ProfitCenterKey)
            {
                var msg = string.Format("You are not authorized to create/modify worksheet for submission: {0} - {1}.",
                    submission?.SubNbr, submission?.InsuredName);
                errorList.Add(new APIResultMessageModel{MessageText = msg });
            }

            return errorList;
        }

        private IEnumerable<APIResultMessageModel> VerifyQuoteDates(QuoteModel quoteModel)
        {
            var errorList = new List<APIResultMessageModel>();

            if (quoteModel.ExpirationDate.Date <= quoteModel.EffectiveDate.Date)
            {
                errorList.Add(new APIResultMessageModel { MessageText = "Expiration date must be past the effective date" });
            }
            return errorList;
        }
    }
}
