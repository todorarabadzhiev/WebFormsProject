using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class SiteCategoriesPresenterMock : SiteCategoriesPresenter
    {
        public ISiteCategoryDataProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public SiteCategoriesPresenterMock(ISiteCategoriesView view, ISiteCategoryDataProvider provider) 
            : base(view, provider)
        {
        }
    }
}
