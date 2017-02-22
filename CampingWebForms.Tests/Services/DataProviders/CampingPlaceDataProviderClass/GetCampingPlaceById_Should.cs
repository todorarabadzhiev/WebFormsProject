using NUnit.Framework;
using Repositories;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace CampingWebForms.Tests.Services.DataProviders.CampingPlaceDataProviderClass
{
    [TestFixture]
    public class GetCampingPlaceById_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();

        private string placeName_01 = "Name_01";
        private string placeName_02 = "Name_02";
        private string placeName_03 = "Name_03";

        private string userName_01 = "User_01";
        private string userName_02 = "User_02";
        private string userName_03 = "User_03";

        [Test]
        public void CallsExactlyOnceCampingPlaceRepositoryMethodGetByIdWithCorrectArgument()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;

            // Act
            provider.GetCampingPlaceById(id);

            // Assert
            Mock.Assert(() => repository.GetCampingPlaceRepository().GetById(id), Occurs.Once());
        }

        [Test]
        public void ReturnsNull_WhenCampingPlaceIsNotFound()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;
            CampingDB.Models.CampingPlace dbPlace = null;
            Mock.Arrange(() => repository.GetCampingPlaceRepository().GetById(id)).Returns(dbPlace);

            // Act
            IEnumerable<ICampingPlace> foundPlace = provider.GetCampingPlaceById(id);

            // Assert
            Assert.IsNull(foundPlace);
        }

        [Test]
        public void ReturnsNull_WhenCampingPlaceIsFoundButTheIsDeletedPropertyIsTrue()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;
            CampingDB.Models.CampingPlace dbPlace = new CampingDB.Models.CampingPlace() { Id = id, IsDeleted = true };
            Mock.Arrange(() => repository.GetCampingPlaceRepository().GetById(id)).Returns(dbPlace);

            // Act
            IEnumerable<ICampingPlace> foundPlace = provider.GetCampingPlaceById(id);

            // Assert
            Assert.IsNull(foundPlace);
        }

        [Test]
        public void ReturnsCorrectCampingPlace_WhenCampingPlaceIsFoundByIdAndItsIsDeletedPropertyIsFalse()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            Guid id = this.id_01;
            ICampingPlace expectedPlace = this.GetCampingPlaces()
                .Where(p => p.Id == id)
                .FirstOrDefault();
            CampingDB.Models.CampingPlace dbPlace = this.GetDbCampingPlaces()
                .Where(p => p.Id == id)
                .FirstOrDefault();
            Mock.Arrange(() => repository.GetCampingPlaceRepository().GetById(id)).Returns(dbPlace);

            // Act
            IEnumerable<ICampingPlace> foundPlaces = provider.GetCampingPlaceById(id);

            // Assert
            Assert.AreEqual(1, foundPlaces.Count());
            foreach (var foundPlace in foundPlaces)
            {
                Assert.AreEqual(foundPlace.Id, expectedPlace.Id);
                Assert.AreEqual(foundPlace.Name, expectedPlace.Name);
            }
        }

        private IEnumerable<ICampingPlace> GetCampingPlaces()
        {
            IEnumerable<ICampingPlace> places = new List<ICampingPlace>()
            {
                new CampingPlace()
                {
                    Id = this.id_01,
                    Name = this.placeName_01,
                    AddedBy = this.userName_01
                },
                new CampingPlace()
                {
                    Id = this.id_02,
                    Name = this.placeName_02,
                    AddedBy = this.userName_02
                },
                new CampingPlace()
                {
                    Id = this.id_03,
                    Name = this.placeName_03,
                    AddedBy = this.userName_01
                }
            };

            return places;
        }

        private IEnumerable<CampingDB.Models.CampingPlace> GetDbCampingPlaces()
        {
            IEnumerable<CampingDB.Models.CampingPlace> dbPlaces =
                new List<CampingDB.Models.CampingPlace>()
            {
                new CampingDB.Models.CampingPlace()
                {
                    Id = this.id_01,
                    Name = this.placeName_01,
                    AddedBy = new CampingDB.Models.CampingUser()
                    {
                        UserName = this.userName_01
                    },
                    Description = "",
                    GoogleMapsUrl = "",
                    WaterOnSite = false,
                    IsDeleted = false,
                    AddedOn = DateTime.Now,
                    ImageFiles = new List<CampingDB.Models.ImageFile>(),
                    Sightseeings = new List<CampingDB.Models.Sightseeing>(),
                    SiteCategories = new List<CampingDB.Models.SiteCategory>()
                },
                new CampingDB.Models.CampingPlace()
                {
                    Id = this.id_02,
                    Name = this.placeName_02,
                    AddedBy = new CampingDB.Models.CampingUser()
                    {
                        UserName = this.userName_02
                    }
                },
                new CampingDB.Models.CampingPlace()
                {
                    Id = this.id_03,
                    Name = this.placeName_03,
                    AddedBy = new CampingDB.Models.CampingUser()
                    {
                        UserName = this.userName_03
                    }
                }
            };

            return dbPlaces;
        }
    }
}
