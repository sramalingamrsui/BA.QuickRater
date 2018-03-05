using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Location;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class LocationFactors
    {
        public BaseLocation Location { get; set; } 
        public bool LocationValidationOverride { get; set; } 
        public string TerritoryCode { get; set; }
    }
}
