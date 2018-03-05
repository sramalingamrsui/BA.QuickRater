using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace RSUI.BA.Rating.Data.Entities
{
    public class MstClassCode
    {
        public virtual int ClassCodeId { get; set; }
        public virtual int ClassCode { get; set; }
		public virtual int Subcode { get; set; }
		public virtual string Description { get; set; }
        public virtual MstExposureBase ExposureBase { get; set; }
        public virtual IsoClassCode IsoClassCode { get; set; }
		public virtual Elp Elp { get; set; }

	}

    public class MstClassCodeMap : ClassMap<MstClassCode>
    {
        public MstClassCodeMap()
        {
            Cache.ReadOnly();
            Table("Mst_ClassCodes");
            Id(x => x.ClassCodeId);
            Map(x => x.ClassCode);
			Map(x => x.Subcode);
			Map(x => x.Description);
            References(x => x.ExposureBase, "ExposureBaseId").NotFound.Ignore().Not.LazyLoad();
			References(x => x.Elp, "RatingIsoClassCodeId").NotFound.Ignore().Not.LazyLoad();
			References(x => x.IsoClassCode, "RatingIsoClassCodeId").NotFound.Ignore().Not.LazyLoad();
        }
    }
}
