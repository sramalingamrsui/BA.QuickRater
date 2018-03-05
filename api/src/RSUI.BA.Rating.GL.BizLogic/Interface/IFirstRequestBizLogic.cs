using System.Collections.Generic;
using System.Xml;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.GL.BizLogic.DTO;
using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.GL.BizLogic.Interface
{
    public interface IFirstRequestBizLogic
    {
        void GetClassCodeDetails(List<ClassCodeRateModel> classcodes, RateInfoResponseModel rateInfoResponse, List<MstClassCode> mstClassCodes);
    }
}
