using System.Reflection;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace AutofacAndAutomapper.Mapping
{
    public class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<Profile>()
                .As<Profile>()
                .AutoActivate();
        }
    }
}