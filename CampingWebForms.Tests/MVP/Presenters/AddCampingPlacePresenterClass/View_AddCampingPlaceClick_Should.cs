using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.AddCampingPlacePresenterClass
{
    [TestFixture]
    public class View_AddCampingPlaceClick_Should
    {
        [Test]
        public void AddCorrectSiteCategoriesToViewModel_WhenAddCampingPlaceLoadEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<IAddCampingPlaceView>();
            var campingPlaceProvider = Mock.Create<ICampingPlaceDataProvider>();
            var sightseeingProvider = Mock.Create<ISightseeingDataProvider>();
            var siteCategoryProvider = Mock.Create<ISiteCategoryDataProvider>();
            AddCampingPlacePresenter presenter = new AddCampingPlacePresenter(view,
                campingPlaceProvider, sightseeingProvider, siteCategoryProvider);
            string name = "SomeName";
            string addedBy = "SomeUser";
            string description = "Description";
            string googleMapsUrl = "Position";
            bool hasWater = false;
            IEnumerable<string> sightseeingNames = new List<string>();
            IEnumerable<string> siteCategoryNames = new List<string>();
            IList<string> imageFileNames = new List<string>();
            IList<byte[]> imageFilesData = new List<byte[]>();

            // Act
            Mock.Raise(() => view.AddCampingPlaceClick += null, new AddCampingPlaceClickEventArgs(
                name, addedBy, description, googleMapsUrl, hasWater,
                sightseeingNames, siteCategoryNames, 
                imageFileNames, imageFilesData));

            // Assert
            Mock.Assert(() => campingPlaceProvider.AddCampingPlace(
                name, addedBy, description, googleMapsUrl, hasWater,
                sightseeingNames, siteCategoryNames, imageFileNames, imageFilesData), 
                Occurs.Once());
        }
    }
}
