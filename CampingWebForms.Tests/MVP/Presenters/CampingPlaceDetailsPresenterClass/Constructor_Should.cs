using CampingWebForms.Tests.Mocked;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.CampingPlaceDetailsPresenterClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithMessageCampingPlaceDataProvider_WhenCampingPlaceDataProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<ICampingPlaceDetailsView>();
            ICampingPlaceDataProvider provider = null;
            string expectedMessage = "CampingPlaceDataProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new CampingPlaceDetailsPresenter(view, provider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignCorrectValueToProvider_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<ICampingPlaceDetailsView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();

            // Act
            var presenter = new CampingPlaceDetailsPresenterMock(view, provider);

            // Assert
            Assert.AreSame(provider, presenter.Provider);
        }
    }
}
