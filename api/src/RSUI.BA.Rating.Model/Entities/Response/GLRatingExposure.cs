using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class GLRatingExposure
    {
        public string ExposureType { get; set; }
        public string ExposureDataType { get; set; }
        public int QuestionID { get; set; }
        public string Question { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public bool Mandatory { get; set; }
        public int ExposureDivisor { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public bool HidenExposure { get; set; }
    }
}
