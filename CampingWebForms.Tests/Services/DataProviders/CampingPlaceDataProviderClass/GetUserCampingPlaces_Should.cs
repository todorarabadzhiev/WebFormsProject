using NUnit.Framework;
using Repositories;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Telerik.JustMock;

namespace CampingWebForms.Tests.Services.DataProviders.CampingPlaceDataProviderClass
{
    [TestFixture]
    public class GetUserCampingPlaces_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();

        private string placeName_01 = "Name_01";
        private string placeName_02 = "Name_02";
        private string placeName_03 = "Name_03";

        private string userName_01 = "User_01";
        private string userName_02 = "User_02";

        [Test]
        public void ReturnNull_WhenProvidedUserNameIsNull()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);

            // Act
            var places = provider.GetUserCampingPlaces(null);

            // Assert
            Assert.IsNull(places);
        }

        [Test]
        public void CallsExactlyOnceCampingPlaceRepositoryMethodGetAllWithTypeOfExpressionAsArgument_WhenProvidedUserNameIsValid()
        {
            // Arrange
            string userName = this.userName_01;
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);

            // Act
            var places = provider.GetUserCampingPlaces(userName);

            // Assert
            Mock.Assert(() => repository.GetCampingPlaceRepository().GetAll(Arg.IsAny<Expression<Func<CampingDB.Models.CampingPlace, bool>>>()), Occurs.Once());
        }

        [Test]
        public void ReturnUserCampingPlaces_WhenProvidedUserNameIsValid()
        {
            // Arrange
            string userName = this.userName_01;
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            var expectedPlaces = this.GetCampingPlaces()
                .Where(p => p.AddedBy == userName);
            var dbPlaces = this.GetDbCampingPlaces()
                .Where(p => p.AddedBy.UserName == userName);
            Mock.Arrange(() => repository.GetCampingPlaceRepository()
                .GetAll(Arg.IsAny<Expression<Func<CampingDB.Models.CampingPlace, bool>>>()))
                .Returns(dbPlaces);

            // Act
            var places = provider.GetUserCampingPlaces(userName);

            // Assert
            Assert.AreEqual(expectedPlaces.Count(), places.Count());
            foreach (var doublePlace in expectedPlaces.Zip(places, Tuple.Create))
            {
                Assert.AreEqual(doublePlace.Item1.Id, doublePlace.Item2.Id);
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
                    }
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
                        UserName = this.userName_01
                    }
                }
            };

            return dbPlaces;
        }
    }
}
