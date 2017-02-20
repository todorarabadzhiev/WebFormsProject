using MVP.Models.EventModels;
using MVP.Views;
using Services.DataProviders;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class MyCampingPlacesPresenter : Presenter<IMyCampingPlacesView>
    {
        private readonly ICampingPlaceDataProvider provider;
        public MyCampingPlacesPresenter(IMyCampingPlacesView view, ICampingPlaceDataProvider provider)
            : base(view)
        {
            this.provider = provider;

            this.View.MyCampingPlacesGetData += this.View_MyCampingPlacesGetData;
            this.View.MyCampingPlacesDeleteItem += this.View_MyCampingPlacesDeleteItem;
        }

        private void View_MyCampingPlacesDeleteItem(object sender, IdEventArgs e)
        {
            this.provider.DeleteCampingPlace(e.Id);
        }

        private void View_MyCampingPlacesGetData(object sender, NameEventArgs e)
        {
            this.View.Model.MyCampingPlaces = this.provider.GetUserCampingPlaces(e.Name);
        }
    }
}
