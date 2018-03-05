using log4net.Layout;
using System.Text;

namespace RSUI.BA.Rating.API.Logging
{
    public class EmailLayout : PatternLayout
    {

        public EmailLayout()
        {
            ConversionPattern = BuildConversionPattern();
        }

        private string BuildConversionPattern()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Message: %m %n");
            sb.Append("Exception: %exception %n");
            sb.Append("%n");
            sb.Append("Username: %identity %n");
            sb.Append("Date: %date %n");
            sb.Append("Properties: %property %n");
            sb.Append("Application: %appdomain %n");
            sb.Append("%n");
            sb.Append("Log Level: %level %n");
            sb.Append("Method: %method %n");
            sb.Append("Logger: %logger %n");
            sb.Append("File: %file %n");
            sb.Append("Location: %location %n");
            sb.Append("%n");
            return sb.ToString();
        }
    }
}
