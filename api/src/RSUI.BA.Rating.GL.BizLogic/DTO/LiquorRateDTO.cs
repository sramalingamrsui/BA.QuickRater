using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.GL.BizLogic.DTO
{
    public class LiquorRateDTO
    {
        public int ClassCode { get; set; }
        public string State { get; set; }
        public int OccLimit { get; set; }
        public int AggLimit { get; set; }
        public decimal LossCost { get; set; }
        public decimal ILFRate { get; set; }
        public decimal LCM { get; set; }
        public decimal Surcharge { get; set; }
        public decimal UnmodifiedRate { get; set; }
        public decimal Rate { get; set; }
    }
}
