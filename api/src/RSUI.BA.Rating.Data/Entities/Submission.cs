using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RSUI.Common.Utils.ObjectUtil;
using RSUI.Common.Utils.Text;

namespace RSUI.BA.Rating.Data.Entities
{
    public class Submission
    {

        private int subRecNbr;
        private int? subNbr;
        private DateTime? currentEffDate;
        private DateTime? currentExpDate;
        private string insuredName;
        private string insuredCity;
        private string insuredState;

        private Department department;
      
        private InsuranceCompany co;
        private PolicySymbol policySymObj = null;
       

        public virtual int SubRecNbr
        {
            get { return subRecNbr; }
            set { subRecNbr = value; }
        }

        public virtual string InsuredName
        {
            get { return insuredName; }
            set { insuredName = value; }
        }

        public virtual string InsuredCity
        {
            get { return insuredCity; }
            set { insuredCity = value; }
        }

        public virtual string InsuredState
        {
            get { return insuredState; }
            set { insuredState = value; }
        }

        public virtual Department Department
        {
            get { return department; }
            set { department = value; }
        }
       public virtual InsuranceCompany InsuranceCompany
        {
            get { return co; }
            set { co = value; }
        }
        public virtual int? SubNbr
        {
            get { return subNbr; }
            set { subNbr = value; }
        }

        public virtual PolicySymbol PolicySymbol
        {
            get { return policySymObj; }
            set { policySymObj = value; }
        }

        public virtual DateTime? CurrentEffDate
        {
            get { return currentEffDate; }
            set { currentEffDate = value; }
        }

        public virtual DateTime? CurrentExpDate
        {
            get { return currentExpDate; }
            set { currentExpDate = value; }
        }
    }

    public struct PolicyNumber
    {
        readonly string _companyCode;
        readonly string _policySymbol;
        readonly int _policyNbr;
        readonly int _policySuffix;

        public static PolicyNumber EMPTY_POLICY_NUMBER =
            new PolicyNumber(null, null, Int32.MinValue, Int32.MinValue);

        public PolicyNumber(string aCompanyCode, string aPolicySymbol, int aPolicyNbr, int aPolicySuffix)
        {
            _companyCode = aCompanyCode;
            _policySymbol = aPolicySymbol;
            _policyNbr = aPolicyNbr;
            _policySuffix = aPolicySuffix;
        }

        public static bool IsEmpty(PolicyNumber policyNumber)
        {
            return (policyNumber._companyCode == null &&
                policyNumber._policySymbol == null &&
                policyNumber._policyNbr == int.MinValue &&
                policyNumber._policySuffix == int.MinValue);

        }

        public string CompanyCode
        {
            get { return _companyCode; }
        }

        public string Symbol
        {
            get { return _policySymbol; }
        }

        public int Number
        {
            get { return _policyNbr; }
        }

        public int Suffix
        {
            get { return _policySuffix; }
        }

        public string FormattedPolicyNumber
        {
            get
            {
                string formattedPolicyNumber = string.Empty;
                formattedPolicyNumber = FormatUtils.GetPolicyNumberDisplay(CompanyCode, Symbol, Number, Suffix);
                return formattedPolicyNumber;
            }
        }

        public string FormattedPolicyNumberNoCompanyCode
        {
            get
            {
                string formattedPolicyNumber = string.Empty;
                formattedPolicyNumber = FormatUtils.GetPolicyNumberDisplay(Symbol, Number, Suffix);
                return formattedPolicyNumber;
            }
        }

        public string FormattedPolicyNumberNoSuffix
        {
            get
            {
                string formattedPolicyNumber = string.Empty;
                formattedPolicyNumber = FormatUtils.GetPolicyNumberDisplay(CompanyCode, Symbol, Number);
                return formattedPolicyNumber;
            }
        }

        public string FormattedPolicyNumberNoCCNoSuffix
        {
            get
            {
                string formattedPolicyNumber = string.Empty;
                formattedPolicyNumber = FormatUtils.GetPolicyNumberDisplay(Symbol, Number);
                return formattedPolicyNumber;
            }
        }
        public override string ToString()
        {
            return string.Format("company code[{0}]   symbol[{1}]   number[{2}]  suffix[{3}]", CompanyCode, Symbol, Number, Suffix);
        }

        public static PolicyNumber Parse(string aPolNbrStr)
        {
            if (aPolNbrStr == null)
                throw new ArgumentNullException("aPolNbrStr");

            //first trim all non-alphas and check length
            string pol = Regex.Replace(aPolNbrStr, @"[^\w\.@-]", "").ToUpper();
            if (pol.Length < 9 || pol.Length > 11)
                throw new ArgumentException(string.Format("Policy number string [{0}] does not seem to be a valid policy number.", aPolNbrStr));

            // Regex match
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"([A-Z]{1})([A-Z]{2})([\d]{6})([\d]{0,2})", options);

            // Get match
            Match match = regex.Match(pol);
            if (match == null)
                throw new ApplicationException(string.Format("Error parsing trimmed policy number string [{0}].  Orig string was [{1}].", pol, aPolNbrStr));

            // construct pol nbr 
            int nbr = Convert.ToInt32(match.Groups[3].Value);
            int suffix = Convert.ToInt32((match.Groups[4].Value.Equals("") ? "0" : match.Groups[4].Value));
            PolicyNumber p =
                new PolicyNumber(match.Groups[1].Value,
                                 match.Groups[2].Value,
                                 nbr,
                                 suffix);

            return p;
        }

        public override bool Equals(object obj)
        {
            var other = (PolicyNumber)obj;
            bool isEqual =
                CompanyCode.Equals(other.CompanyCode) &&
                Symbol.Equals(other.Symbol) &&
                Number.Equals(other.Number) &&
                Suffix.Equals(other.Suffix);
            return isEqual;
        }

        public override int GetHashCode()
        {
            return HashCodeUtils.ComputeHashFrom(_companyCode, _policySymbol, _policyNbr, _policySuffix);
        }
    }
}