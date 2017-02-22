using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.CreateUserPresenterClass
{
    [TestFixture]
    public class View_CreateUserClick_Should
    {
        [Test]
        public void CallAddCampingUserMethodOfProvider_WhenCreateUserClickEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<ICreateUserView>();
            var provider = Mock.Create<ICampingUserDataProvider>();
            CreateUserPresenter presenter = new CreateUserPresenter(view, provider);
            string firstName = "FirstName";
            string lastName = "LastName";
            string userName = "UserName";
            string appUserId = "ApplicationUserId";

            // Act
            Mock.Raise(() => view.CreateUserClick += null, 
                new CreateUserClickEventArgs(appUserId, firstName, lastName, userName));

            // Assert
            Mock.Assert(() => provider.AddCampingUser(appUserId, firstName, lastName, userName),
                Occurs.Once());
        }
    }
}
