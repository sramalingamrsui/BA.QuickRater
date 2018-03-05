using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSUI.BA.Rating.Model
{
    public class APIUser
    {
        public bool InternalUser { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public int? LocationSKey { get; set; }
        public int? CompanySKey { get; set; }
        public string CompanyPrefix { get; set; }
        public string UserID { get; set; }
        public string MGAReferenceNumber { get; set; }
        public string LoggingCorrelationID { get; set; }
        public  int? PeopleSKey { get; set; }
        public  int? EmpRecNbr { get; set; }
        public int? EmpProfitCenter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}