using MVP.Models.EventModels;
using MVP.Views;
using Services.DataProviders;
using System;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class AddCampingPlacePresenter : Presenter<IAddCampingPlaceView>
    {
        protected readonly ICampingPlaceDataProvider campingPlaceProvider;
        protected readonly ISightseeingDataProvider sightseeingProvider;
        protected readonly ISiteCategoryDataProvider siteCategoryProvider;

        public AddCampingPlacePresenter(IAddCampingPlaceView view, ICampingPlaceDataProvider campingPlaceProvider,
            ISightseeingDataProvider sightseeingProvider, ISiteCategoryDataProvider siteCategoryProvider)
            : base(view)
        {
            if (campingPlaceProvider == null)
            {
                throw new ArgumentNullException("CampingPlaceProvider");
            }

            if (siteCategoryProvider == null)
            {
                throw new ArgumentNullException("SiteCategoryProvider");
            }

            if (sightseeingProvider == null)
            {
                throw new ArgumentNullException("SightseeingProvider");
            }

            this.campingPlaceProvider = campingPlaceProvider;
            this.sightseeingProvider = sightseeingProvider;
            this.siteCategoryProvider = siteCategoryProvider;

            this.View.AddCampingPlaceLoad += this.View_AddCampingPlaceLoad;
            this.View.AddCampingPlaceClick += this.View_AddCampingPlaceClick;
        }

        private void View_AddCampingPlaceClick(object sender, AddCampingPlaceClickEventArgs e)
        {
            this.campingPlaceProvider.AddCampingPlace(e.Name, e.AddedBy, e.Description, e.GoogleMapsUrl,
                e.HasWater, e.SightseeingNames, e.SiteCategoryNames, 
                e.ImageFileNames, e.ImageFilesData);
        }

        private void View_AddCampingPlaceLoad(object sender, EventArgs e)
        {
            this.View.Model.SiteCategories = this.siteCategoryProvider.GetAllSiteCategories();
            this.View.Model.Sightseeings = this.sightseeingProvider.GetAllSightseeings();
        }
    }
}
