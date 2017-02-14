using CampingWebForms.Services;
using CampingWebForms.Views;
using System;
using WebFormsMvp;

namespace CampingWebForms.Presenters
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private readonly IDataProvider provider;
        public HomePresenter(IHomeView view, IDataProvider provider)
            : base(view)
        {
            this.provider = provider;

            this.View.HomeLoad += this.View_HomeLoad;
        }

        private void View_HomeLoad(object sender, EventArgs e)
        {
            this.View.Model.CampingPlaces = this.provider.GetAllCampingPlaces();
        }
    }
}