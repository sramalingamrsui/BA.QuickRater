using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Exceptions = new APIValidation()
            {
                Errors = new List<string>(),
                Warnings = new List<string>()
            };
        }
        public APIValidation Exceptions { get; set; }
    }
}
