using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Location;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class FinalLocationResponse
    {
        public APILocation FinalLocation { get; set; } 
        public string FinalTerritoryCode { get; set; } 
        public decimal? DistanceToCoast { get; set; } 
        public bool StateWindEligible { get; set; } 
    }
}
