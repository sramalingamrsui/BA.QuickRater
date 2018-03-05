using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.GL
{
    public class ClassCodeDetails: ClassCodeBase
    {
        public string Scope { get; set; }
        public string Notes { get; set; }
        public string Details { get; set; }
        public string Eligibilty { get; set; }
        public string ManualPageURL { get; set; }
    }
}
