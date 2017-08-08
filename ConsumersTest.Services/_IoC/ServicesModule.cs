using Autofac;
using ConsumersTest.Services.Interfaces;
using ConsumersTest.Services.Services;
using ConsumersTest.Wcf._IoC;

namespace ConsumersTest.Services._IoC
{
    public class ServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<WcfModule>();

            builder.RegisterType<ConsumerService>()
                .As<IConsumerService>()
                .InstancePerLifetimeScope();
        }
    }
}
