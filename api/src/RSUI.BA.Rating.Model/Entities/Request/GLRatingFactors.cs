using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class GLRatingFactors:ClassCodeBase 
    {
        public RatedBy RatedBy { get; set; }
        public bool ExcludeProducts { get; set; }
        public decimal? PremisesDiscretionaryModifier { get; set; }
        public decimal? ProductsDiscretionaryModifier { get; set; }
        public decimal? MinimumPremium { get; set; }
        public List<ClassCodeRatingAnswer> CompanyPremiseAnswers { get; set; }
        public List<ClassCodeRatingAnswer> CompanyProductsAnswers { get; set; }
        public List<ClassCodeRatingAnswer> ISOPremiseAnswers { get; set; }
        public List<ClassCodeRatingAnswer> ISOAdditionalQuestionAnswers { get; set; }
        public List<ClassCodeRatingAnswer> CompanyAdditionalQuestionAnswers { get; set; }
        public decimal? ISOAAPremRate { get; set; }
        public decimal? ISOAAProdRate { get; set; }
    }
}
