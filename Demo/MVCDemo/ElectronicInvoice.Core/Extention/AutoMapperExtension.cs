using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;

namespace ElectronicInvoice.Core.Extension
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperProfileByAssembly(this ContainerBuilder builder,params Assembly[] assemblies)
        {
            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(assemblies).As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }

                cfg.ValidateInlineMaps = false;

            })).AsSelf();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}