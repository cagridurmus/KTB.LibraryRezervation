using System.Reflection;
using Autofac;
using KTB.LibraryRezervation.Core.Repositories;
using KTB.LibraryRezervation.Core.Services;
using KTB.LibraryRezervation.Core.UnitOfWorks;
using KTB.LibraryRezervation.Repositories;
using KTB.LibraryRezervation.Repositories.Repositories;
using KTB.LibraryRezervation.Repositories.UnitOfWorks;
using KTB.LibraryRezervation.Services.Mapping;
using KTB.LibraryRezervation.Services.Services;
using Module = Autofac.Module;

namespace KTB.LibraryRezervation.API.Modules
{
    public class RepoServiceModule: Module
	{
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}

