using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Data.Entities;

namespace RSUI.BA.Rating.GL.BizLogic.Interface
{
    public interface IGLLookUp
    {
        List<string> OccurenceAggregateLimits { get; }
        List<string> PRCOLimits { get; }
        List<string> PersAndAdvInjuryLimits { get; }
        List<string> DamagesToPremisesLimits { get; }
        List<string> MedicalExpenseLimits { get; }
        List<string> Deductibles { get; }

        List<MstClassCode> MstClassCodes { get; set; }
        List<Submission> Submissions { get; set; }
        List<MstState> MstStates { get; set; }
        MstClassCode GetMstClassCode(string classCode);
    }
}
