using Autofac;
using ConsumersTest.Services._IoC;

namespace ConsumersTest._IoC
{
    public class AppModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServicesModule>();
        }
    }
}