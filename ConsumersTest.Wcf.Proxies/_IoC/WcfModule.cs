using Autofac;
using ConsumersTest.Wcf.Contracts.Services;
using ConsumersTest.Wcf.Proxies;

namespace ConsumersTest.Wcf._IoC
{
    public class WcfModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var consumerClient = new ConsumerWcfClient("BasicHttpsBinding_IConsumerService");
                return consumerClient;
            })
                .As<IConsumerWcfService>()
                .InstancePerLifetimeScope();
        }
    }
}
