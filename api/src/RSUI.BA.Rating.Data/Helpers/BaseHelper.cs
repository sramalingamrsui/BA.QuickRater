
using Autofac.Features.Indexed;
using NHibernate;
using RSUI.BA.Rating.Data.IoC;

namespace RSUI.BA.Rating.Data.Helpers
{
    public class BaseHelper
    {
        public ISession RSUIDBSession { get { return _sessions[Databases.RSUI]; } }
        public ISession GLRatingDBSession { get { return _sessions[Databases.Rating]; } }

        private IIndex<Databases, ISession> _sessions { get; set; }



        public BaseHelper(IIndex<Databases, ISession> sessions)
        {
            _sessions = sessions;
        }
    }
}
