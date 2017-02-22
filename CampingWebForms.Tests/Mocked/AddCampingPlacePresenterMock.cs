using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class AddCampingPlacePresenterMock : AddCampingPlacePresenter
    {
        public ICampingPlaceDataProvider CampingPlaceProvider
        {
            get
            {
                return this.campingPlaceProvider;
            }
        }

        public ISightseeingDataProvider SightseeingProvider
        {
            get
            {
                return this.sightseeingProvider;
            }
        }

        public ISiteCategoryDataProvider SiteCategoryProvider
        {
            get
            {
                return this.siteCategoryProvider;
            }
        }

        public AddCampingPlacePresenterMock(IAddCampingPlaceView view, ICampingPlaceDataProvider campingPlaceProvider, ISightseeingDataProvider sightseeingProvider, ISiteCategoryDataProvider siteCategoryProvider) 
            : base(view, campingPlaceProvider, sightseeingProvider, siteCategoryProvider)
        {
        }
    }
}
