using System;
using System.Web.Mvc;
using System.Data.Entity;
using Autofac;
using Autofac.Integration.Mvc;
using BusinessLogic;
using BusinessLogicApi;
using DataAccess;
using DataAccessApi;
using VersionControlCore;
using VersionControlCoreApi;

namespace Container
{
    public sealed class XRMVersionControlContainer
    {
        private readonly IContainer _autofac;

        public XRMVersionControlContainer()
        {
            Database.SetInitializer<DataContext>(new TestDbInitializer());

            var builder = new ContainerBuilder();

            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies())
                .PropertiesAutowired()
                .InstancePerHttpRequest();
            builder.RegisterType<DataContext>().As<DataContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<VersionControlService>().As<IVersionControlService>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
            builder.RegisterType<VersionControlParser>().As<IVersionControlParser>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
            builder.RegisterType<VersionControlRepository>().As<IVersionControlRepository>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
            _autofac = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(_autofac));
        }
    }
}
