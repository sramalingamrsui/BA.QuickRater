using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace RSUI.BA.Rating.Data.Entities
{
    public class MstState
    {
        public virtual int StateId { get; set; }
        public virtual string State { get; set; }
        public virtual string StateCode { get; set; }
    }

    public class MstStateMap : ClassMap<MstState>
    {
        public MstStateMap()
        {
            Cache.ReadOnly();
            Table("Mst_State");
            Where("IsActive = 1");
            Id(x => x.StateId);
            Map(x => x.State, "StateName");
            Map(x => x.StateCode);
        }
    }
}
