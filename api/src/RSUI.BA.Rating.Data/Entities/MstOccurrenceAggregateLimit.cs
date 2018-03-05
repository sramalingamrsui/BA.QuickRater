using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace RSUI.BA.Rating.Data.Entities
{
    public class MstOccurrenceAggregateLimit
    {
        public virtual int OccurrenceAggregateLimitId { get; set; }
        public virtual int Occurrence { get; set; }
        public virtual int Aggregate { get; set; }
        public virtual Decimal Factor { get; set; }

    }

    public class MstOccurrenceAggregateLimitMap : ClassMap<MstOccurrenceAggregateLimit>
    {
        public MstOccurrenceAggregateLimitMap()
        {
            Cache.ReadOnly();
            Table("[Mst_OccurrenceAggregateLimits]");
            Where("IsActive = 1");
            Id(x => x.OccurrenceAggregateLimitId);
            Map(x => x.Occurrence);
            Map(x => x.Aggregate, "GeneralAggregate");
            Map(x => x.Factor);
        }
    }
}
