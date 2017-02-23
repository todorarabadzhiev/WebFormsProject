using CampingWebForms.Tests.Mocked;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.SiteCategoryPlacesPresenterClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstanceOfSiteCategoryPlacesPresenter_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<ISiteCategoryPlacesView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();

            // Act
            SiteCategoryPlacesPresenter presenter = new SiteCategoryPlacesPresenter(view, provider);

            // Assert
            Assert.IsInstanceOf<SiteCategoryPlacesPresenter>(presenter);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageCampingPlaceDataProvider_WhenCampingPlaceDataProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<ISiteCategoryPlacesView>();
            ICampingPlaceDataProvider provider = null;
            string expectedMessage = "CampingPlaceDataProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new SiteCategoryPlacesPresenter(view, provider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignCorrectValueToProvider_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<ISiteCategoryPlacesView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();

            // Act
            var presenter = new SiteCategoryPlacesPresenterMock(view, provider);

            // Assert
            Assert.AreSame(provider, presenter.Provider);
        }
    }
}
