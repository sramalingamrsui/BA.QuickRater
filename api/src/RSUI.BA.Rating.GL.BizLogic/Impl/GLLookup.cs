using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.GL.BizLogic.Interface;

namespace RSUI.BA.Rating.GL.BizLogic.Impl
{
        public class GLLookup : IGLLookUp
        {
            public static string PRCO_NOTCOVERED = "-- NOT COVERED --";

            public List<MstClassCode> MstClassCodes { get; set; }
            public List<MstState> MstStates { get; set; }
            public List<Submission> Submissions { get; set; }
            public List<string> OccurenceAggregateLimits
            {
                get
                {
                    var list = new List<string>();

                    list.Add("$1,000,000/$1,000,000");
                    list.Add("$1,000,000/$2,000,000");
                    list.Add("$2,000,000/$2,000,000");
                    list.Add("$2,000,000/$4,000,000");

                    return list;
                }
            }

            public List<string> PRCOLimits
            {
                get
                {
                    var list = new List<string>();

                    list.Add("$1,000,000");
                    list.Add("$2,000,000");
                    list.Add("$4,000,000");
                    list.Add(PRCO_NOTCOVERED);

                    return list;
                }
            }

            public List<string> PersAndAdvInjuryLimits
            {
                get
                {
                    var list = new List<string>();

                    list.Add("$1,000,000");
                    list.Add("$2,000,000");
                    list.Add("-- NOT COVERED --");

                    return list;
                }
            }

            public MstClassCode GetMstClassCode(string classCode)
            {
                return MstClassCodes.FirstOrDefault(cc => cc.ClassCode.ToString() == classCode);
            }

            public List<string> DamagesToPremisesLimits
            {
                get
                {
                    var list = new List<string>();

                    list.Add("$50,000");
                    list.Add("$100,000");
                    list.Add("$150,000");
                    list.Add("$250,000");
                    list.Add("$300,000");
                    list.Add("$500,000");
                    list.Add("-- NOT COVERED --");

                    return list;
                }
            }

            public List<string> MedicalExpenseLimits
            {
                get
                {
                    var list = new List<string>();

                    list.Add("$1,000");
                    list.Add("$2,000");
                    list.Add("$2,500");
                    list.Add("$5,000");
                    list.Add("$10,000");
                    list.Add("- NOT COVERED --");

                    return list;
                }
            }

            public List<string> Deductibles
            {
                get
                {
                    var list = new List<string>();

                    list.Add("$5,000");
                    list.Add("$10,000");

                    return list;
                }
            }
        }
    }