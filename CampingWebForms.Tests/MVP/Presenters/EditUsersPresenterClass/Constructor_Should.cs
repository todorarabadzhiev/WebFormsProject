using CampingWebForms.Tests.Mocked;
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

namespace CampingWebForms.Tests.MVP.Presenters.EditUsersPresenterClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithMessageCampingUserDataProvider_WhenCampingUserDataProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<IEditUsersView>();
            ICampingUserDataProvider provider = null;
            string expectedMessage = "CampingUserDataProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new EditUsersPresenter(view, provider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignCorrectValueToProvider_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<IEditUsersView>();
            var provider = Mock.Create<ICampingUserDataProvider>();

            // Act
            var presenter = new EditUsersPresenterMock(view, provider);

            // Assert
            Assert.AreSame(provider, presenter.Provider);
        }
    }
}
