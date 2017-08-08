using Autofac;
using ConsumersTest.Services.Interfaces;
using ConsumersTest.Services.Services;

namespace ConsumersTest.Services._IoC
{
    public class ServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsumerService>()
                .As<IConsumerService>()
                .InstancePerLifetimeScope();
        }
    }
}
