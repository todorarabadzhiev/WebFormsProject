using NUnit.Framework;
using Repositories;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.Services.DataProviders.CampingUserDataProviderClass
{
    [TestFixture]
    public class AddCampingUser_Should
    {
        private string appUserId = "SomeUserId";
        private string firstName = "First Name";
        private string lastName = "Last Name";
        private string userName = "User Name";

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenProvidedFirstNameIsNull()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);
            string expectedMessage = "FirstName";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => provider.AddCampingUser(
                this.appUserId, null, this.lastName, this.userName));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenProvidedLastNameIsNull()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);
            string expectedMessage = "LastName";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => provider.AddCampingUser(
                this.appUserId, this.firstName, null, this.userName));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenProvidedUserNameIsNull()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);
            string expectedMessage = "UserName";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => provider.AddCampingUser(
                this.appUserId, this.firstName, this.lastName, null));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenProvidedAppUserIdIsNull()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);
            string expectedMessage = "ApplicationUserId";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => provider.AddCampingUser(
                null, this.firstName, this.lastName, this.userName));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void CallsExactlyOnceCampingUserRepositoryMethodAddWithValidArgument_WhenProvidedArgumentsAreValid()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);

            // Act
            provider.AddCampingUser(this.appUserId, this.firstName,
                this.lastName, this.userName);

            // Assert
            Mock.Assert(() => repository.GetCampingUserRepository().Add(Arg.IsAny<CampingDB.Models.CampingUser>()), Occurs.Once());
        }

        [Test]
        public void CallsExactlyOnceUnitOfWorkMethodCommit_WhenProvidedArgumentsAreValid()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);

            // Act
            provider.AddCampingUser(this.appUserId, this.firstName,
                this.lastName, this.userName);

            // Assert
            Mock.Assert(() => unitOfWork().Commit(), Occurs.Once());
        }

    }
}
