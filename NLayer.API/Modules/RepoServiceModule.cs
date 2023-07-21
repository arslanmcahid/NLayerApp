using Autofac;
using NLayer.Caching;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using System.Data;
using System.Reflection;
using Module=Autofac.Module; // module reflection kisminda da vardi o yuzden hangisinden istedigimiz karismasin diye bu tarz bi gosterim yaptik
namespace NLayer.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));// reposirtory katmanindaki herhangi bir sinifi tip olarak vererek assembly tanitiyoruz
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));// burada da service katmanindan bir cs dosyasi ile tanittik

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            // InstancePerLifetimeScope bu method program.cs deki Scope'a denk gelmektedir
            // InstancePerDependency ise transient e karsilik gelmektedir

            //builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();





            /*
             * I'd rather go to the stake
             * I2ll be dead awake rising from stake and when u hear the follogin tune
             * 
             */


        }
    }
}
