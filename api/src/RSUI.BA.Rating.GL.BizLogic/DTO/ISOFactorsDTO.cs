using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.GL.BizLogic.DTO
{
    public class ISOFactorsDTO
    {
        public int ClassCode { get; set; }
        public string StateCode { get; set; }
        public string Territory { get; set; }
        public string Deductible { get; set; }
        public string OccLimit { get; set; }
        public string AggLimit { get; set; }
        public Decimal PremLossCost { get; set; }
        public Decimal ProdLossCost { get; set; }
        public Decimal PremILFRate { get; set; }
        public Decimal ProdILFRate { get; set; }
        public Decimal PremDeductibleFactor { get; set; }
        public Decimal ProdDeductibleFactor { get; set; }
        public Decimal LCM { get; set; }
        public Decimal Surcharge { get; set; }
        public string ProductsHazrdLevel { get; set; }
        public string PremisesHazardLevel { get; set; }
        public string PremisesLossCostIndicator { get; set; }
        public string ProductsLossCostIndicator { get; set; }
        public Decimal PremisesELP { get; set; }
        public Decimal ProductsELP { get; set; }
    }
}
