using CampingWebForms.Services;
using CampingWebForms.Views;
using System;
using WebFormsMvp;
using CampingWebForms.Models;

namespace CampingWebForms.Presenters
{
    public class AddCampingPlacePresenter : Presenter<IAddCampingPlaceView>
    {
        private readonly IDataProvider provider;
        public AddCampingPlacePresenter(IAddCampingPlaceView view, IDataProvider provider) 
            : base(view)
        {
            this.provider = provider;

            this.View.AddCampingPlaceLoad += this.View_AddCampingPlaceLoad;
            this.View.AddCampingPlaceClick += this.View_AddCampingPlaceClick;
        }

        private void View_AddCampingPlaceClick(object sender, AddCampingPlaceClickEventArgs e)
        {
            this.provider.AddCampingPlace(e.Name, e.Description, e.GoogleMapsUrl,
                e.HasWater, e.SightseeingNames, e.SiteCategoryNames);
        }

        private void View_AddCampingPlaceLoad(object sender, EventArgs e)
        {
            this.View.Model.SiteCategories = this.provider.GetAllSiteCategories();
            this.View.Model.Sightseeings = this.provider.GetAllSightseeings();
        }
    }
}