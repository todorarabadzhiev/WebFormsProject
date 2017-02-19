using Ninject.Modules;
using Services.DataProviders;

namespace CampingWebForms.App_Start.NinjectModules
{
    public class CampingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICampingPlaceDataProvider>().To<CampingPlaceDataProvider>();
            this.Bind<ICampingUserDataProvider>().To<CampingUserDataProvider>();
            this.Bind<ISiteCategoryDataProvider>().To<SiteCategoryDataProvider>();
            this.Bind<ISightseeingDataProvider>().To<SightseeingDataProvider>();
        }
    }
}