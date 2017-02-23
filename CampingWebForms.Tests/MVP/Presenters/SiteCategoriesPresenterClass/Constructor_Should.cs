using CampingWebForms.Tests.Mocked;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.SiteCategoriesPresenterClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstanceOfSiteCategoriesPresenter_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<ISiteCategoriesView>();
            var provider = Mock.Create<ISiteCategoryDataProvider>();

            // Act
            var presenter = new SiteCategoriesPresenter(view, provider);

            // Assert
            Assert.IsInstanceOf<SiteCategoriesPresenter>(presenter);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageSiteCategoryProvider_WhenSiteCategoryDataProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<ISiteCategoriesView>();
            ISiteCategoryDataProvider provider = null;
            string expectedMessage = "SiteCategoryProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new SiteCategoriesPresenter(view, provider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignCorrectValueToProvider_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<ISiteCategoriesView>();
            var provider = Mock.Create<ISiteCategoryDataProvider>();

            // Act
            var presenter = new SiteCategoriesPresenterMock(view, provider);

            // Assert
            Assert.AreSame(provider, presenter.Provider);
        }
    }
}
