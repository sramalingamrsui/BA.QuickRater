using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using log4net;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.Data.Helpers;
using RSUI.BA.Rating.GL.BizLogic.DTO;
using RSUI.BA.Rating.GL.BizLogic.Interface;
using RSUI.BA.Rating.Model;
using RSUI.Common.Utils.Collection;

namespace RSUI.BA.Rating.GL.BizLogic.Impl
{
    public class FirstRequestBizLogic : IFirstRequestBizLogic
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(FirstRequestBizLogic));

        private readonly IGLHelper _glHelper;
        private readonly IGLLookUp _glLookup;

        public FirstRequestBizLogic(IGLHelper glHelper, IGLLookUp glLookup)
        {
            // _premiumBases = GLRatingDBSession.Query<PremiumBasis>().ToList();
            _glHelper = glHelper;
            _glLookup = glLookup;
        }

        public void GetClassCodeDetails(List<ClassCodeRateModel> classcodes, RateInfoResponseModel rateInfoResponse, List<MstClassCode> mstClassCodes)
        {
            if (classcodes.Any())
            {
                foreach (var classcode in classcodes)
                {
                    var mstClassCode = _glLookup.GetMstClassCode(classcode.Number);

                    classcode.Description = mstClassCode.Description;
                    AttachIsoExposures(classcode, mstClassCode.ExposureBase);
                }
            }
        }

        private void AttachIsoExposures(ClassCodeRateModel matchingClassCodeModel, MstExposureBase exposureBase)
        {
            matchingClassCodeModel.ClassCodeRateInfo.RateInfo = new RateInfoModel
            {
                Exposure = new ExposureRateInfoModel
                {
                    ExposureDataType = exposureBase.ValueType,
                    ExposureDivisor = exposureBase.ExposureBaseValue.ToString(),
                    ExposureBasis = exposureBase.ExposureBaseType,
                    QuestionID = "1",
                    Question = matchingClassCodeModel.Description,
                }
            };
        }
    }
}
