using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace RSUI.BA.Rating.Data.Entities
{
    public class QuestionFieldType
    {
        public virtual int Id { get; set; }
        public virtual string FieldType { get; set; }
    }

    public class QuestionFieldTypeMap : ClassMap<QuestionFieldType>
    {
        public QuestionFieldTypeMap()
        {
            Cache.ReadOnly();
            Table("QuestionFieldType");
            Id(x => x.Id);
            Map(x => x.FieldType);
        }
    }
}
