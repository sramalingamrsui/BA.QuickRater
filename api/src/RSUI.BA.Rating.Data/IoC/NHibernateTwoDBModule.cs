using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Reflection;
using Autofac;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Configuration = NHibernate.Cfg.Configuration;


namespace RSUI.BA.Rating.Data.IoC
{

    public enum Databases {RSUI, Rating}


    public class NHibernateTwoDBModule : Autofac.Module
    {
        public string RSUIConnectionName { get; set; }
        public string RatingConnectionName { get; set; }
        public bool SessionPerRequest { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            Contract.Assert(builder != null, "Builder container is null");
            Assembly assembly = Assembly.GetAssembly(typeof(NHibernateTwoDBModule));

            var globalconfig = new Configuration().Configure();

            var rsuiDbCfg = new Configuration().Configure()
                .SetProperty(NHibernate.Cfg.Environment.ConnectionString, GetConnectionString(RSUIConnectionName));

            var rsuiDbPersistenceModel = new PersistenceModel();
            rsuiDbPersistenceModel.AddMappingsFromAssembly(assembly);
            rsuiDbPersistenceModel.Configure(rsuiDbCfg);

            var ratingDbCfg = new Configuration().Configure()
                .SetProperty(NHibernate.Cfg.Environment.ConnectionString, GetConnectionString(RatingConnectionName));

            var ratingDbPersistenceModel = new PersistenceModel();
            ratingDbPersistenceModel.AddMappingsFromAssembly(assembly);
            ratingDbPersistenceModel.Configure(ratingDbCfg);

            var sessionFactory1 = rsuiDbCfg.BuildSessionFactory();
            var sessionFactory2 = ratingDbCfg.BuildSessionFactory();

            RegisterComponents(builder, globalconfig, sessionFactory1, sessionFactory2);
        }

        public Configuration BuildConfiguration()
        {
            var cfg = new Configuration();
            cfg.Configure();

            if (cfg == null)
                throw new Exception("Cannot build NHibernate configuration");

            return cfg;
        }

        private string GetConnectionString(string name)
        {
            var connStringSetting = ConfigurationManager.ConnectionStrings[name];
            if (connStringSetting == null)
                throw new Exception(name + " connection not found.");
            return connStringSetting.ConnectionString;

        }

        public ISessionFactory BuildSessionFactory(Configuration config)
        {
            var sessionFactory = config.BuildSessionFactory();

            if (sessionFactory == null)
                throw new Exception("Cannot build NHibernate Session Factory");

            return sessionFactory;
        }

        public void RegisterComponents(ContainerBuilder builder, Configuration config, ISessionFactory sessionFactory1, ISessionFactory sessionFactory2)

        {
            builder.RegisterInstance(config).As<Configuration>().SingleInstance();
            builder.RegisterInstance(sessionFactory1).As<ISessionFactory>().Keyed<ISessionFactory>(Databases.RSUI).SingleInstance();
            builder.RegisterInstance(sessionFactory2).As<ISessionFactory>().Keyed<ISessionFactory>(Databases.Rating).SingleInstance();

            if (SessionPerRequest)
            {
                builder.Register(x => x.ResolveKeyed<ISessionFactory>(Databases.RSUI).OpenSession())
                    .As<ISession>()
                    .Keyed<ISession>(Databases.RSUI)
                    .InstancePerRequest();
                builder.Register(x => x.ResolveKeyed<ISessionFactory>(Databases.Rating).OpenSession())
                    .As<ISession>()
                    .Keyed<ISession>(Databases.Rating)
                    .InstancePerRequest();
            }
            else
            {
                builder.Register(x => x.ResolveKeyed<ISessionFactory>(Databases.RSUI).OpenSession())
                    .As<ISession>()
                    .Keyed<ISession>(Databases.RSUI)
                    .InstancePerDependency();
                builder.Register(x => x.ResolveKeyed<ISessionFactory>(Databases.Rating).OpenSession())
                    .As<ISession>()
                    .Keyed<ISession>(Databases.Rating)
                    .InstancePerDependency();
   
            }
        }

    }


}
