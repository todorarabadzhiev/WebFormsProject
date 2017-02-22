using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.EditUsersPresenterClass
{
    [TestFixture]
    public class View_EditUsersGetCampingUsers_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();

        private string name_01 = "Name_01";
        private string name_02 = "Name_02";
        private string name_03 = "Name_03";

        [Test]
        public void AddCorrectCampingUsersToViewModel_WhenEditUsersGetCampingUsersEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<IEditUsersView>();
            var provider = Mock.Create<ICampingUserDataProvider>();
            var campingUsers = this.GetCampingUsers();
            Mock.Arrange(() => provider.GetAllCampingUsers()).Returns(campingUsers);
            EditUsersPresenter presenter = new EditUsersPresenter(view, provider);

            // Act
            Mock.Raise(() => view.EditUsersGetCampingUsers += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(campingUsers, view.Model.CampingUsers);
        }

        private IEnumerable<ICampingUser> GetCampingUsers()
        {
            IEnumerable<ICampingUser> campingUsers =
                new List<ICampingUser>()
            {
                new CampingUser()
                {
                    Id = this.id_01,
                    UserName = this.name_01
                },
                new CampingUser()
                {
                    Id = this.id_02,
                    UserName = this.name_02
                },
                new CampingUser()
                {
                    Id = this.id_03,
                    UserName = this.name_03
                }
            };

            return campingUsers;
        }
    }
}
