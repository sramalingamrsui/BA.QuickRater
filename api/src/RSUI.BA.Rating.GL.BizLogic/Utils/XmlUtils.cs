using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Autofac.Core;
using log4net;

namespace RSUI.BA.Rating.GL.BizLogic.Utils
{
    public class XmlUtils
    {
        private static readonly RemoteCertificateValidationCallback SslFailureCallback = new RemoteCertificateValidationCallback(delegate { return true; });
        private static readonly ILog log = LogManager.GetLogger(typeof(XmlUtils));


        static XmlUtils()
        {
            ServicePointManager.ServerCertificateValidationCallback += SslFailureCallback;                 
        }


        public static string SerializeToString(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());

            using (var writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, obj);

                return writer.ToString();
            }
        }

        public static XmlDocument SendXmlRequest(string ServiceUrl, string strXmlRequest)
        {


            var xmlDoc = new XmlDocument();
            var encoding = new ASCIIEncoding();
            // sample xml sent to Service & this data is sent in POST
            // string SampleXml = strXmlRequest;
            var postData = strXmlRequest;
            // convert xmlstring to byte using ascii encoding
            var data = encoding.GetBytes(postData);

            var webrequest = (HttpWebRequest) WebRequest.Create(ServiceUrl);
            webrequest.Method = "POST";
            webrequest.ContentType = "text/xml";
            webrequest.ContentLength = data.Length;
            // get stream data out of webrequest object
            var newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            var webresponse = (HttpWebResponse) webrequest.GetResponse();

            xmlDoc.Load(webresponse.GetResponseStream());
            webresponse.Close();
            //need to do a little parsing magic to get the actual XML
            xmlDoc.LoadXml(xmlDoc.InnerText);


            return xmlDoc;

        }

    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
