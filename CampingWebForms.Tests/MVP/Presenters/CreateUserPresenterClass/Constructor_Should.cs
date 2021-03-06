﻿using CampingWebForms.Tests.Mocked;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.CreateUserPresenterClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstanceOfCreateUserPresenter_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<ICreateUserView>();
            var provider = Mock.Create<ICampingUserDataProvider>();

            // Act
            CreateUserPresenter presenter = new CreateUserPresenter(view, provider);

            // Assert
            Assert.IsInstanceOf<CreateUserPresenter>(presenter);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageCampingUserDataProvider_WhenCampingUserDataProviderArgumentIsNull()
        {
            // Arrange
            var view = Mock.Create<ICreateUserView>();
            ICampingUserDataProvider provider = null;
            string expectedMessage = "CampingUserDataProvider";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new CreateUserPresenter(view, provider));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignCorrectValueToProvider_WhenArgumentIsValid()
        {
            // Arrange
            var view = Mock.Create<ICreateUserView>();
            var provider = Mock.Create<ICampingUserDataProvider>();

            // Act
            var presenter = new CreateUserPresenterMock(view, provider);

            // Assert
            Assert.AreSame(provider, presenter.Provider);
        }
    }
}
