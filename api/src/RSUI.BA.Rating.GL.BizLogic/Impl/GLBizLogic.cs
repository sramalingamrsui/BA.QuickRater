using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Autofac.Features.Indexed;
using NHibernate;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.Data.IoC;
using RSUI.BA.Rating.GL.BizLogic.DTO;
using RSUI.BA.Rating.GL.BizLogic.Interface;
using RSUI.BA.Rating.Model;

namespace RSUI.BA.Rating.GL.BizLogic.Impl
{
    public class GLBizLogic : IGLBizLogic
    {
        private IFirstRequestBizLogic _firstRequestBizLogic;
        protected IIndex<Databases, ISession> _sessions { get; set; }
        public GLBizLogic(IFirstRequestBizLogic firstRequestBizLogic, IIndex<Databases, ISession> sessions)
        {
            _firstRequestBizLogic = firstRequestBizLogic;
            _sessions = sessions;
        }

        public void GetClassCodeDetails(List<ClassCodeRateModel> classcodes, RateInfoResponseModel rateInfoResponse, List<MstClassCode> mstClassCodes)
        {
            _firstRequestBizLogic.GetClassCodeDetails(classcodes, rateInfoResponse, mstClassCodes);
        }
    }
}
