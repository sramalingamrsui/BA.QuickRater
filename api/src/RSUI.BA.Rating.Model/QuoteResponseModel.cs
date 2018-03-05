
using System.Collections.Generic;

namespace RSUI.BA.Rating.Model
{
    public class QuoteResponseModel
    {
        public QuoteResponseModel()
        {
            ApiResult = new APIResultModel();
        }
        public APIResultModel ApiResult { get; set; }
        public QuoteModel Quote { get; set; }
        public IEnumerable<QuoteModel> Quotes { get; set; }
    }
}
