using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Configuration;
using FluentNHibernate.Mapping;

namespace RSUI.BA.Rating.Data.Entities
{
    public class Elp
    {
        public virtual int ClassCodeId { get; set; }
        public virtual Decimal? PremiseElp { get; set; }
        public virtual Decimal? ProductsElp { get; set; }
    }

    public class ElpMap : ClassMap<Elp>
    {
        public ElpMap()
        {
            Cache.ReadOnly();
            Table("Elp");
            Where(string.Format("IsActive = 1 and CarrierID = {0}", ConfigurationManager.AppSettings["Carrier_ID"]));
            Id(x => x.ClassCodeId);
            Map(x => x.PremiseElp);
            Map(x => x.ProductsElp, "ProductElp");
        }
    }
}
