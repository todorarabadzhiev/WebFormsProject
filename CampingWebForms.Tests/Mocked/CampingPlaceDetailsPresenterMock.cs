using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class CampingPlaceDetailsPresenterMock : CampingPlaceDetailsPresenter
    {
        public ICampingPlaceDataProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public CampingPlaceDetailsPresenterMock(ICampingPlaceDetailsView view, ICampingPlaceDataProvider provider) 
            : base(view, provider)
        {
        }
    }
}
