using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace RSUI.BA.Rating.API
{
    public class WebApiApplication : HttpApplication
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof (WebApiApplication));

        protected void Application_BeginRequest()
        {
            if (Request.HttpMethod == "OPTIONS")
            {
                _logger.Debug("OPIONS request");
                HttpContext.Current.Response.End();
            }
        }
    }
}