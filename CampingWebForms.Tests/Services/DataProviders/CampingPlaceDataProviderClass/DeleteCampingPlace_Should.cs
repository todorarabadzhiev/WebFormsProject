using CampingDB.Models;
using NUnit.Framework;
using Repositories;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.Services.DataProviders.CampingPlaceDataProviderClass
{
    [TestFixture]
    public class DeleteCampingPlace_Should
    {
        private Guid id_01 = Guid.NewGuid();

        [Test]
        public void CallsExactlyOnceCampingPlaceRepositoryMethodGetByIdWithCorrectArgument()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;

            // Act
            provider.DeleteCampingPlace(id);

            // Assert
            Mock.Assert(() => repository.GetCampingPlaceRepository().GetById(id), Occurs.Once());
        }

        [Test]
        public void CallsExactlyOnceUnitOfWorkMethodCommit_WhenCampingPlaceIsFound()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;
            CampingPlace dbPlace = Mock.Create<CampingPlace>();
            Mock.Arrange(() => repository.GetCampingPlaceRepository().GetById(id)).Returns(dbPlace);

            // Act
            provider.DeleteCampingPlace(id);

            // Assert
            Mock.Assert(() => unitOfWork().Commit(), Occurs.Once());
        }

        [Test]
        public void DoesNotCallUnitOfWorkMethodCommit_WhenCampingPlaceIsNotFound()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;
            CampingPlace dbPlace = null;
            Mock.Arrange(() => repository.GetCampingPlaceRepository().GetById(id)).Returns(dbPlace);

            // Act
            provider.DeleteCampingPlace(id);

            // Assert
            Mock.Assert(() => unitOfWork().Commit(), Occurs.Never());
        }

        [Test]
        public void ChangesPropertyIsDeletedOfTheFoundCampingPlaceToTrue_WhenCampingPlaceIsFound()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;
            CampingPlace dbPlace = Mock.Create<CampingPlace>();
            dbPlace.IsDeleted = false;
            Mock.Arrange(() => repository.GetCampingPlaceRepository().GetById(id)).Returns(dbPlace);

            // Act
            provider.DeleteCampingPlace(id);

            // Assert
            Assert.AreEqual(true, dbPlace.IsDeleted);
        }
    }
}
