using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Shared
{
    public class Address
    {
        #region Private Members
        private string _AddressLine1 = string.Empty;
        private string _AddressLine2 = string.Empty;
        private string _City = string.Empty;
        private string _ZipCode = string.Empty;
        private string state = string.Empty;
        private string _county = string.Empty;
        private string _territory = string.Empty;
        #endregion

        #region public Members

        public string Territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        public string AddressLine1
        {
            get { return _AddressLine1; }
            set { _AddressLine1 = value; }
        }

        public string AddressLine2
        {
            get { return _AddressLine2; }
            set { _AddressLine2 = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }

        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        public string StateAbbreviation
        {
            get { return state; }
            set { state = value; }
        }

        #endregion

    }
}
