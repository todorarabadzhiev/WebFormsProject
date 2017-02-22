using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class MyCampingPlacesPresenterMock : MyCampingPlacesPresenter
    {
        public ICampingPlaceDataProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public MyCampingPlacesPresenterMock(IMyCampingPlacesView view, ICampingPlaceDataProvider provider) 
            : base(view, provider)
        {
        }
    }
}
