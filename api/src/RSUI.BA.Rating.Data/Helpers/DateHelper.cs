using System;
using Autofac.Features.Indexed;
using NHibernate;
using RSUI.BA.Rating.Data.Interface;
using RSUI.BA.Rating.Data.IoC;

namespace RSUI.BA.Rating.Data.Helpers
{
    public class DateHelper :BaseHelper, IDateHelper
    {


        public DateHelper(IIndex<Databases, ISession> sessions):base(sessions)
        {
           
        }

        public DateTime GetDatabaseDateTime()
        {
            //return DateTime.Now;
            //using (IoCContainer. .ResolveKeyed<ISessionFactory>(Databases.RSUI).OpenSession())
            return RSUIDBSession.CreateSQLQuery("select GetDate()").UniqueResult<DateTime>();
        }
    }
}
