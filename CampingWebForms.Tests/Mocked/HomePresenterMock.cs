using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class HomePresenterMock : HomePresenter
    {
        public ICampingPlaceDataProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public HomePresenterMock(IHomeView view, ICampingPlaceDataProvider provider) 
            : base(view, provider)
        {
        }
    }
}
