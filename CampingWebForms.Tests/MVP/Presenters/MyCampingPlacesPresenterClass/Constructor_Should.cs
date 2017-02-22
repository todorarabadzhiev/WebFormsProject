using CampingWebForms.Tests.Mocked;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.MyCampingPlacesPresenterClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithMessageCampingPlaceProvider_WhenCampingPlaceDataProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<IMyCampingPlacesView>();
            ICampingPlaceDataProvider provider = null;
            string expectedMessage = "CampingPlaceProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new MyCampingPlacesPresenter(view, provider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignCorrectValueToProvider_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<IMyCampingPlacesView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();

            // Act
            var presenter = new MyCampingPlacesPresenterMock(view, provider);

            // Assert
            Assert.AreSame(provider, presenter.Provider);
        }
    }
}
