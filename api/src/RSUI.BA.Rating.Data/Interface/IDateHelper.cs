using System;
using NHibernate;

namespace RSUI.BA.Rating.Data.Interface
{
    public interface IDateHelper
    {
        DateTime GetDatabaseDateTime();
        ISession RSUIDBSession { get; }
        ISession GLRatingDBSession { get; } 
    }
}
