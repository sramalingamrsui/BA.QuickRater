using System;
using System.Collections.Generic;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.GL.BizLogic.DTO;
using RSUI.BA.Rating.Model;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.GL.BizLogic.Interface
{
    public interface IGLHelper
    {
        void ParseLimits(out int aggLimit, out int occLimit, string aggregateOccurenceLimits);

        RatesModel GetISORate(string limts, string deductible, LocationModel location, MstClassCode classCode, string effectiveDate);

        void LoadGlTables();
    }
}
