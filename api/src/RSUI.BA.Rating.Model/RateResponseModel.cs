using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSUI.BA.Rating.Model
{
    [XmlRoot("RateResponse")]
    public class RateResponseModel
    {
        public string APIIdentifier { get; set; }

        public APIResultModel APIResult { get; set; }


        public SummaryInfoModel SummaryInfo { get; set; }

        [XmlArray("LocationSchedule")]
        [XmlArrayItem("Location", typeof(LocationModel))]
        public List<LocationModel> LocationSchedule { get; set; }


        public GLCoverageModel GlCoverage { get; set; }

        public PropertyCoverageModel PropertyCoverage { get; set; }
    }
}
