using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class ISORateInfo
    {
        public decimal? CompanyLostCostMultiplier { get; set; }
        public decimal? AdditionalModifier { get; set; }
        public decimal? PremisesLossCostRate { get; set; }
        public decimal? PremisesRSUIAdjustedRate { get; set; }
        public decimal? PremisesILFRate { get; set; }
        public decimal? ProductsLossCostRate { get; set; }
        public decimal? ProductsRSUIAdjustedRate { get; set; }
        public decimal? ProductsILFRate { get; set; }
        public bool ProductsRateEditable { get; set; }
        public bool PremisesRateEditable { get; set; }
    }
}
