using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace RSUI.BA.Rating.Data.Entities
{
    public class IsoClassCode
    {
        public virtual int ClassCodeId { get; set; }
        public virtual int ClassCode { get; set; }
    }

    public class IsoClassCodeMap : ClassMap<IsoClassCode>
    {
        public IsoClassCodeMap()
        {
            Cache.ReadOnly();
            Table("UWClassCodes");
            Id(x => x.ClassCodeId);
            Map(x => x.ClassCode);
        }
    }
}
