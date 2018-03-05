using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Request
{
    public class RatesAndExposuresGLFactors
    {
        public string AggregateOccurenceLimits { get; set; }
        public string Deductible { get; set; }
        public List<ClassCodeBase> ClassCodes { get; set; }

        public bool ExludeMetaData { get; set; }
    }
}
