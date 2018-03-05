using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.Data.Interface
{
    public interface IQuoteModelValidator
    {
        void ValidateQuoteModel(QuoteModel quoteModel, APIResultModel apiResult, APIUser currentUser);
    }
}
