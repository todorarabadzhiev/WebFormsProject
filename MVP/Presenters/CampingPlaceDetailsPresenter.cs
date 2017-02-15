using MVP.Models.EventModels;
using MVP.Views;
using Services.DataProviders;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class CampingPlaceDetailsPresenter : Presenter<ICampingPlaceDetailsView>
    {
        private readonly IDataProvider provider;
        public CampingPlaceDetailsPresenter(ICampingPlaceDetailsView view, IDataProvider provider)
            : base(view)
        {
            this.provider = provider;

            this.View.CampingPlaceDetailsLoad += this.View_CampingPlaceDetailsLoad;
        }

        private void View_CampingPlaceDetailsLoad(object sender, CampingPlaceDetailsEventArgs e)
        {
            this.View.Model.CampingPlaceDetails = this.provider.GetCampingPlaceById(e.Id);
        }
    }
}
