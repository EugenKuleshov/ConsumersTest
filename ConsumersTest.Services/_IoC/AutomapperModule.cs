using Autofac;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsumersTest.Services._IoC
{
    internal class AutomapperModule: Autofac.Module
    {
        private readonly Assembly[] _assemblies;

        public AutomapperModule(params Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterMapper(builder);
            RegisterProfiles(builder);
            RegisterServices(builder);
        }

        private void RegisterMapper(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var profiles = c.Resolve<IEnumerable<Profile>>();
                var mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    foreach (var profile in profiles)
                        cfg.AddProfile(profile);
                });
                mapperConfiguration.AssertConfigurationIsValid();
                return mapperConfiguration;
            }).As<IConfigurationProvider>()
                .SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = c.Resolve<IConfigurationProvider>();
                return new Mapper(config, context.Resolve);
            }).As<IMapper>()
                .InstancePerLifetimeScope();
        }

        private void RegisterProfiles(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_assemblies)
                .Where(x => x.IsSubclassOf(typeof(Profile)))
                .As<Profile>()
                .SingleInstance();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            var genericInterfaces = new[]
            {
                typeof(ITypeConverter<,>),
                typeof(IValueResolver<,,>),
                typeof(IMemberValueResolver<,,,>)
            };

            var interfacesImplementations = _assemblies.SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass &&
                            x.GetInterfaces().Where(i => i.IsGenericType)
                                .Any(i => genericInterfaces.Contains(i.GetGenericTypeDefinition()))).ToList();

            foreach (var type in interfacesImplementations)
            {
                if (type.IsGenericType)
                {
                    builder.RegisterGeneric(type)
                        .AsSelf()
                        .InstancePerLifetimeScope();
                }
                else
                {
                    builder.RegisterType(type)
                        .AsSelf()
                        .InstancePerLifetimeScope();
                }
            }
        }
    }
}
