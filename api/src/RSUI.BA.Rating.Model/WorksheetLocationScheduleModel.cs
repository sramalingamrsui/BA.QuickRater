using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model
{
    public class WorksheetLocationScheduleModel
    {
        public string PremisesNumber { get; set; }
        public string City { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public string State { get; set; }
        [DisplayName("Territory Code")]
        public string TerritoryCode { get; set; }
    }
}
