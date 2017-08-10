using Autofac;
using ConsumersTest.DataAccess.Infrastructure;
using ConsumersTest.DataAccess.Infrastructure.Interfaces;

namespace ConsumersTest.DataAccess._IoC
{
    public class DataAccessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new AppConfigConnectionFactory("ConsumerDbString"))
                .As<IConnectionFactory>()
                .SingleInstance();

            builder.RegisterType<AdoNetContext>()
                .As<IDataContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AdoNetUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            RegisterRepositories(builder);
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
