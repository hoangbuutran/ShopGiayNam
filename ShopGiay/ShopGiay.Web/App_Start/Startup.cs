using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using ShopGiay.Data.Infrastructure;
using System.Reflection;
using ShopGiay.Data;
using ShopGiay.Data.Repositories;
using ShopGiay.Service;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Web.Http;

[assembly: OwinStartup(typeof(ShopGiay.Web.App_Start.Startup))]

namespace ShopGiay.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<ShopGiayDbContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(ThuongHieuRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(ThuongHieuService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }
    }
}
