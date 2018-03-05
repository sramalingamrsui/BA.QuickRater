using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Data.Entities
{
    public class Department
    {
        private int deptNbr = 0;
        private int profitCenterKey = 0;
        private string deptDesc;

        #region convenience constants
        public const int CASUALTYKEY = 111;  //this is a "virtual" department; denotes a profit center containing 100, 1800
        public const int UMBRELLAKEY = 100;
        public const int PROPERTYKEY = 200;
        public const int DNOKEY = 300;
        public const int SIRKEY = 1500;
        public const int GLKEY = 1800;
        public const int PROFESSIONALLIABILITYKEY = 1900;
        public const int BINDING_AUTHORITY_KEY = 10006;
        public const int ITKEY = 10003;
        public const int ACCOUNTINGKEY = 10004;
        public const int ADMINKEY = 10005;
        public const int KFC = 2200;
        public const int ALTERNATIVESTRUCTURESKEY = 10007;
        #endregion
        public virtual int DeptNbr
        {
            get { return deptNbr; }
            set { deptNbr = value; }
        }

        public virtual int ProfitCenterKey
        {
            get { return profitCenterKey; }
            set { profitCenterKey = value; }
        }

        public virtual string DeptDesc
        {
            get { return deptDesc; }
            set { deptDesc = value; }
        }
        public virtual bool IsGL
        {
            get { return DeptNbr == GLKEY; }
        }
        public virtual bool IsUmbrella
        {
            get { return DeptNbr == UMBRELLAKEY; }
        }
        public virtual bool IsPL
        {
            get { return DeptNbr == PROFESSIONALLIABILITYKEY; }
        }

    }
}