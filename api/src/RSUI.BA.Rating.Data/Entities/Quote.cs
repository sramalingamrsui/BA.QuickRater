using System;
using System.Linq;
using FluentNHibernate.Mapping;
using RSUI.BA.Rating.Data.Entities;

namespace RSUI.BA.Rating.Data.Entities
{
    public class Quote
    {
        public virtual int QuoteID { get; set; }
        public virtual int QuoteNumber { get; set; }
        public virtual int? SubmissionNo { get; set; }
        public virtual Submission Submission { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime EffectiveDate { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual Employee CreatedByEmployee { get; set; }
        public virtual DateTime LastModifiedDate { get; set; }
        public virtual Employee LastModifiedEmployee { get; set; }
        public virtual string QuoteData { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? GeneratedDate { get; set; }
        public virtual string InsuredName { get; set; }
        public virtual string InsuredCity { get; set; }
        public virtual string InsuredState { get; set; }
        public virtual decimal? Version { get; set; }
    }

    public class QuoteMap : ClassMap<Quote>
    {
        public QuoteMap()
        {
            Table("UWQuote");
            Id(x => x.QuoteID);
            Map(x => x.QuoteNumber);
            Map(x => x.SubmissionNo, "SubmissionNo");
            Map(x => x.Description);
            Map(x => x.EffectiveDate);
            Map(x => x.ExpirationDate);
            Map(x => x.CreateDate);
            Map(x => x.LastModifiedDate);
            Map(x => x.QuoteData).CustomSqlType("varchar(max)").Length(Int32.MaxValue).Nullable();
            Map(x => x.Status);
            Map(x => x.GeneratedDate);
            Map(x => x.InsuredName);
            Map(x => x.InsuredCity);
            Map(x => x.InsuredState);
            Map(x => x.Version);
            References(x => x.Submission, "SubRecordNo").NotFound.Ignore().Not.LazyLoad();
            References(x => x.CreatedByEmployee, "CreatedByEmpRecNbr").NotFound.Ignore().Not.LazyLoad();
            References(x => x.LastModifiedEmployee, "LastModifiedEmpRecNbr").NotFound.Ignore().Not.LazyLoad();
        }
    }
}

