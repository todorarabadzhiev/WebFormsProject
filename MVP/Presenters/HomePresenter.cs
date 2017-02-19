using MVP.Views;
using Services.DataProviders;
using System;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private readonly ICampingPlaceDataProvider provider;
        public HomePresenter(IHomeView view, ICampingPlaceDataProvider provider)
            : base(view)
        {
            this.provider = provider;

            this.View.HomeLoad += this.View_HomeLoad;
        }

        private void View_HomeLoad(object sender, EventArgs e)
        {
            this.View.Model.CampingPlaces = this.provider.GetLatestCampingPlaces(3);
        }
    }
}
