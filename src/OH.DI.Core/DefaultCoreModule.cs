using Autofac;
using OH.DI.Core.Interfaces;
using OH.DI.Core.Services;

namespace OH.DI.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
