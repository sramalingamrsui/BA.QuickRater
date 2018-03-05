using System;
using AutoMapper;
using log4net;
using NHibernate.Transform;
using RSUI.BA.Rating.API.Models;
using System.Linq;
using System.Web.Http;

namespace RSUI.BA.Rating.API.Controllers
{
	[Authorize(Roles = "Access Mobile App")]
    public class ValidateController : ApiController
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ValidateController));

        public ValidateController()
        {
        }

        [Route("api/claims"), HttpGet]
        public ClaimInfo[] Search(string search)
        {
			var candidates = new ClaimInfo[] { new ClaimInfo { InsuredName = "Test1", ClaimNumber = "12345", DateOfLoss = DateTime.Now } };
            return candidates.ToArray();
        }

		[Route("api/validate"), HttpGet]
		public bool Validate()
		{
			return true;
		}
	}
}
