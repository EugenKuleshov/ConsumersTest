using Autofac;
using ConsumersTest.DataAccess._IoC;
using ConsumersTest.Services.Interfaces;
using ConsumersTest.Services.Services;
using ConsumersTest.Wcf._IoC;

namespace ConsumersTest.Services._IoC
{
    public class ServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterModules(builder);
            RegisterServices(builder);            
        }

        private void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutomapperModule(ThisAssembly));
            builder.RegisterModule<WcfModule>();
            builder.RegisterModule<DataAccessModule>();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            //builder.RegisterType<ConsumerWcfSourceService>()
            builder.RegisterType<ConsumerDataAccessSourceService>()            
                .As<IConsumerService>()
                .InstancePerLifetimeScope();
        }
    }
}
