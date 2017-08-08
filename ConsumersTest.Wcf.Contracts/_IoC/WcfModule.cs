using Autofac;
using ConsumersTest.Wcf.ConsumerServiceReference;

namespace ConsumersTest.Wcf._IoC
{
    public class WcfModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => {
                var client = new ConsumerServiceClient("BasicHttpsBinding_IConsumerService");
                return client;
            })
            .As<IConsumerService>()
            .InstancePerLifetimeScope();
        }
    }
}
