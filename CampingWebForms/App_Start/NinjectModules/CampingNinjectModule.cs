using CampingWebForms.Services;
using Ninject.Modules;

namespace CampingWebForms.App_Start.NinjectModules
{
    public class CampingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDataProvider>().To<CampingDbDataProvider>();
        }
    }
}