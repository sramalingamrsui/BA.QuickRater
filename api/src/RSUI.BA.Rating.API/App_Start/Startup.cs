using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using RSUI.BA.Rating.API;
using System.Reflection;
using System.Web.Http;
using RSUI.BA.Rating.Data.Helpers;
using RSUI.BA.Rating.Data.Interface;
using RSUI.BA.Rating.Data.IoC;
using RSUI.BA.Rating.Data.Validator;
using RSUI.BA.Rating.GL.BizLogic.Impl;
using RSUI.BA.Rating.GL.BizLogic.Interface;

[assembly: OwinStartup(typeof(Startup))]
namespace RSUI.BA.Rating.API
{
	public class Startup
    {
        private static IContainer _container;

        public static IContainer Container => _container;

        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();

			HttpConfiguration config = new HttpConfiguration();
            ConfigureIOC(config);
            Security.Configuration.ConfigureOAuth(app, "/api/token");

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        private void ConfigureIOC(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

			builder.RegisterType<GLHelper>().As<IGLHelper>().InstancePerRequest();
			builder.RegisterType<GLValidator>().As<IGLValidator>().InstancePerRequest();
			builder.RegisterType<GLBizLogic>().As<IGLBizLogic>().InstancePerRequest();
			builder.RegisterType<FirstRequestBizLogic>().As<IFirstRequestBizLogic>().InstancePerRequest();
			builder.RegisterType<GLLookup>().As<IGLLookUp>().SingleInstance();
			builder.RegisterType<DateHelper>().As<IDateHelper>().InstancePerRequest();
			builder.RegisterType<RequestModelValidator>().As<IRequestModelValidator>().InstancePerRequest();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterModule(new NHibernateTwoDBModule()
			{
				RSUIConnectionName = "RSUIConnectionString",
				RatingConnectionName = "RatingConnectionString",
				SessionPerRequest = true
			});

			_container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
        }
    }
}