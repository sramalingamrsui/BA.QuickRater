using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class ClassCodeRatesAndExposures:ClassCodeBase 
    {

        public string CanRateBy
        {
            get { return InternalCanRateBy.ToString(); }
        }

        public string PremisesRatingAuthority
        {
            get { return InternalPremisesRatingAuthority.ToString(); }
        }

        public string ProductsRatingAuthority
        {
            get { return InternalProductsRatingAuthority.ToString(); }
        }
        public ISORateInfo ISORateInfo { get; set; }
        public List<GLRatingExposureGroup> ISOPremisesExposureGroups { get; set; }

        public List<AddtionalQuestion> ISOAdditionalQuestions { get; set; }
        public List<AddtionalQuestion> CompanyAdditionalQuestions { get; set; }

        public List<GLRatingExposureGroup> CompanyPremisesExposureGroups { get; set; }
        public List<GLRatingExposureGroup> CompanyProductExposureGroups { get; set; }
        public List<string> CompanyRelatedProductsClassCodes { get; set; }
        public List<string> CompanyRelatedPremiseClassCodes { get; set; }

        public string Scope { get; set; }
        public string Eligibility { get; set; }
        public string LinkToManual { get; set; }
        public string Notes { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public RatingAuthority InternalProductsRatingAuthority { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public RatingAuthority InternalPremisesRatingAuthority { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public CanRateBy InternalCanRateBy { get; set; }

    }
}
