namespace RSUI.BA.Rating.Data.Entities
{
    public class InsuranceCompany
    {
        private int companyRecordNumber = -1;
        private string companyCode;
        private string companyName;


        public virtual int CompanyRecordNumber
        {
            get { return companyRecordNumber; }
            set { companyRecordNumber = value; }
        }

        public virtual string CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }

        public virtual string CompanyName
        {
            get { return string.IsNullOrWhiteSpace(companyName) ? null : companyName.Trim(); }
            set { companyName = value; }
        }

      
    }
}
