using Ninject.Modules;

namespace CampingWebForms.App_Start.NinjectModules
{
    public class DBNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //this.Bind<ICampingDBRepository>().To<CampingDBRepository>();
            //this.Bind<DbContext>().To<CampingDBContext>();
        }
    }
}