using CampingDB;
using Ninject;
using Ninject.Modules;
using Repositories;
using System;
using System.Data.Entity;

namespace CampingWebForms.App_Start.NinjectModules
{
    public class DBNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICampingDBRepository>().To<CampingDBRepository>();
            this.Bind(typeof(IGenericRepository<>)).To(typeof(CampingDBGenericRepository<>));
            this.Bind<DbContext>().To<CampingDBContext>().InSingletonScope();
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<EfUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}