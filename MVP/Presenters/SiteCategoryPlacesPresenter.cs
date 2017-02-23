using MVP.Models.EventModels;
using MVP.Views;
using Services.DataProviders;
using System;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class SiteCategoryPlacesPresenter : Presenter<ISiteCategoryPlacesView>
    {
        protected readonly ICampingPlaceDataProvider provider;

        public SiteCategoryPlacesPresenter(ISiteCategoryPlacesView view, ICampingPlaceDataProvider provider)
            : base(view)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("CampingPlaceDataProvider");
            }

            this.provider = provider;

            this.View.SiteCategoryGetPlaces += this.View_SiteCategoryGetPlaces;
        }

        private void View_SiteCategoryGetPlaces(object sender, NameEventArgs e)
        {
            this.View.Model.CampingPlaces = this.provider.GetSiteCategoryCampingPlaces(e.Name);
        }
    }
}
