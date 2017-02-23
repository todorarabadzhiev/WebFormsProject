using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class SiteCategoryPlacesPresenterMock : SiteCategoryPlacesPresenter
    {
        public ICampingPlaceDataProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public SiteCategoryPlacesPresenterMock(ISiteCategoryPlacesView view, ICampingPlaceDataProvider provider) 
            : base(view, provider)
        {
        }
    }
}
