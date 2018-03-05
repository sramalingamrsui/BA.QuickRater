using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.Common.Legacy.Data.Domain.Utils;

namespace RSUI.BA.Rating.Data.Entities
{
    public class Employee
    {
        #region Private Fields

        private int empRecNum;
        private string empUserProfile;

        private string empLastName;


        private string empFirstName;




        #endregion


        #region Public Properties

        public virtual string Email { get; set; }
        public virtual Department Department { get; set; }

        public virtual int EmpRecNum
        {
            get
            {
                return empRecNum;
            }

            set
            {
                empRecNum = value;
            }

        }


        public virtual string EmpLastName
        {
            get
            {
                return empLastName;
            }

            set
            {
                empLastName = value;
            }

        }

        public virtual string EmpFirstName
        {
            get
            {
                return empFirstName;
            }

            set
            {
                empFirstName = value;
            }

        }



        public virtual string EmpUserProfile
        {
            get
            {
                return empUserProfile;
            }

            set
            {
                empUserProfile = value;
            }

        }


        public virtual string FullName
        {
            get
            {
                if ((empFirstName == null || empFirstName.Trim().Equals(string.Empty)) && (empLastName != null && !empLastName.Trim().Equals(string.Empty)))
                    return empLastName;
                if ((empFirstName != null && !empFirstName.Trim().Equals(string.Empty)) && (empLastName == null || empLastName.Trim().Equals(string.Empty)))
                    return empFirstName;
                if ((empFirstName != null && !empFirstName.Trim().Equals(string.Empty)) && (empLastName != null && !empLastName.Trim().Equals(string.Empty)))
                    return empLastName + ", " + EmpFirstName;
                return string.Empty;
            }
        }


        public virtual string DisplayName
        {
            get
            {
                if ((empFirstName == null || empFirstName.Trim().Equals(string.Empty)) && (empLastName != null && !empLastName.Trim().Equals(string.Empty)))
                    return empLastName;
                if ((empFirstName != null && !empFirstName.Trim().Equals(string.Empty)) && (empLastName == null || empLastName.Trim().Equals(string.Empty)))
                    return empFirstName;
                if ((empFirstName != null && !empFirstName.Trim().Equals(string.Empty)) && (empLastName != null && !empLastName.Trim().Equals(string.Empty)))
                    return EmpFirstName + " " + empLastName;
                return string.Empty;
            }
        }

        #endregion



        public override string ToString()
        {
            return string.Format("Employee [{0}]: {1}", EmpRecNum, FullName);
        }
        public virtual string Initials { get; set; }
    }
}
