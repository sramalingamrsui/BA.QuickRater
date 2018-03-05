using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace RSUI.BA.Rating.Data.Entities
{
    public class MstExposureBase
    {
        public virtual int ExposureBaseId { get; set; }
        public virtual string ExposureBaseType { get; set; }
        public virtual string ExposureQuestion { get; set; }
        public virtual string ExposureDescription { get; set; }
        public virtual int ExposureBaseValue { get; set; }
        public virtual string PremBasisSym { get; set; }
        public virtual string ValueType { get; set; } 

    }

    public class MstExposureBaseMap : ClassMap<MstExposureBase>
    {
        public MstExposureBaseMap()
        {
            Cache.ReadOnly();
            Table("Mst_ExposureBase");
            Id(x => x.ExposureBaseId);
            Map(x => x.ExposureBaseType);
            Map(x => x.ExposureDescription);
            Map(x => x.ExposureBaseValue);
            Map(x => x.PremBasisSym);
            Map(x => x.ExposureQuestion, "ExposureQue");
            Map(x => x.ValueType);
        }
    }
}
