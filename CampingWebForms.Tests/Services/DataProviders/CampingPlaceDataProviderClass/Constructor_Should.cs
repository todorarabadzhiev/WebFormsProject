﻿using CampingWebForms.Tests.Mocked;
using NUnit.Framework;
using Repositories;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.Services.DataProviders.CampingPlaceDataProviderClass
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateCampingPlaceDataProviderInstance_WhenProvidedArgumentsAreValid()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            CampingPlaceDataProvider provider = new CampingPlaceDataProvider(repository, unitOfWork);

            // Act&Assert
            Assert.IsInstanceOf<CampingPlaceDataProvider>(provider);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingCampingDBRepository_WhenProvidedRepositoryIsNull()
        {
            // Arrange
            ICampingDBRepository repository = null;
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            string expectedMessage = "CampingDBRepository";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new CampingPlaceDataProvider(repository, unitOfWork));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingUnitOfWork_WhenProvidedUnitOfWorkIsNull()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = null;
            string expectedMessage = "UnitOfWork";

            // Act&Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new CampingPlaceDataProvider(repository, unitOfWork));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void AssignRepositoryAndUnitOfWorkCorrectValues_WhenProvidedWithValidParameters()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();

            // Act
            var provider = new CampingPlaceDataProviderMock(repository, unitOfWork);

            // Assert
            Assert.AreSame(repository, provider.Repository);
            Assert.AreSame(unitOfWork, provider.UnitOfWork);
        }
    }
}
