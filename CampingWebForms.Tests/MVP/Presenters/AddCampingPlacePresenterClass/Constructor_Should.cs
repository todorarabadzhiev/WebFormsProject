using CampingWebForms.Tests.Mocked;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.AddCampingPlacePresenterClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithMessageCampingPlaceProvider_WhenCampingPlaceProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<IAddCampingPlaceView>();
            ICampingPlaceDataProvider campingPlaceProvider = null;
            ISightseeingDataProvider sightseeingProvider = Mock.Create<ISightseeingDataProvider>();
            ISiteCategoryDataProvider siteCategoryProvider = Mock.Create<ISiteCategoryDataProvider>();
            string expectedMessage = "CampingPlaceProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new AddCampingPlacePresenter(view,
                campingPlaceProvider, sightseeingProvider, siteCategoryProvider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageSiteCategoryProvider_WhenSiteCategoryProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<IAddCampingPlaceView>();
            ICampingPlaceDataProvider campingPlaceProvider = Mock.Create<ICampingPlaceDataProvider>();
            ISightseeingDataProvider sightseeingProvider = Mock.Create<ISightseeingDataProvider>();
            ISiteCategoryDataProvider siteCategoryProvider = null;
            string expectedMessage = "SiteCategoryProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new AddCampingPlacePresenter(view,
                campingPlaceProvider, sightseeingProvider, siteCategoryProvider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageSightseeingProvider_WhenSightseeingProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<IAddCampingPlaceView>();
            ICampingPlaceDataProvider campingPlaceProvider = Mock.Create<ICampingPlaceDataProvider>();
            ISightseeingDataProvider sightseeingProvider = null;
            ISiteCategoryDataProvider siteCategoryProvider = Mock.Create<ISiteCategoryDataProvider>();
            string expectedMessage = "SightseeingProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new AddCampingPlacePresenter(view,
                campingPlaceProvider, sightseeingProvider, siteCategoryProvider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignCorrectValuesToProviders_WhenAllArgumentsAreValid()
        {
            // Arrange
            var view = Mock.Create<IAddCampingPlaceView>();
            ICampingPlaceDataProvider campingPlaceProvider = Mock.Create<ICampingPlaceDataProvider>();
            ISightseeingDataProvider sightseeingProvider = Mock.Create<ISightseeingDataProvider>();
            ISiteCategoryDataProvider siteCategoryProvider = Mock.Create<ISiteCategoryDataProvider>();

            // Act
            var presenter = new AddCampingPlacePresenterMock(view, campingPlaceProvider, sightseeingProvider, siteCategoryProvider);

            // Assert
            Assert.AreSame(campingPlaceProvider, presenter.CampingPlaceProvider);
            Assert.AreSame(sightseeingProvider, presenter.SightseeingProvider);
            Assert.AreSame(siteCategoryProvider, presenter.SiteCategoryProvider);
        }
    }
}
