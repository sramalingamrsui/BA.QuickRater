using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RSUI.BA.Rating.Model
{
    public class WorksheetModel : BaseModel
    {
        [JsonProperty(Order = 1100)]
        public string APIIdentifier { get; set; }
        [JsonProperty(Order = 1200)]
        public string User { get; set; }
        [JsonProperty(Order = 1300)]
        public WorksheetSummaryModel WorksheetSummary { get; set; }
        [JsonProperty(Order = 1400)]
        public List<WorksheetLocationScheduleModel> WorksheetLocationSchedule { get; set; }
        [JsonProperty(Order = 1500)]
        public WorksheetGLModel WorksheetGL { get; set; }
        [JsonProperty(Order = 1600)]
        public WorksheetTotalsModel WorksheetTotals { get; set; }
    }
}
