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
    public class GetSiteCategoryCampingPlaces_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();

        private string placeName_01 = "Name_01";
        private string placeName_02 = "Name_02";
        private string placeName_03 = "Name_03";

        private string categoryName_01 = "Category_01";
        private string categoryName_02 = "Category_02";

        [Test]
        public void ReturnNull_WhenProvidedCategoryNameIsNull()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);

            // Act
            var places = provider.GetSiteCategoryCampingPlaces(null);

            // Assert
            Assert.IsNull(places);
        }

        [Test]
        public void CallsExactlyOnceCampingPlaceRepositoryMethodGetAllWithTypeOfExpressionAsArgument_WhenProvidedCategoryNameIsValid()
        {
            // Arrange
            string categoryName = this.categoryName_01;
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);

            // Act
            var places = provider.GetSiteCategoryCampingPlaces(categoryName);

            // Assert
            Mock.Assert(() => repository.GetCampingPlaceRepository().GetAll(p => (!p.IsDeleted) &&
            (p.SiteCategories.FirstOrDefault(s => s.Name == categoryName) != null)), Occurs.Once());
            //Mock.Assert(() => repository.GetCampingPlaceRepository().GetAll(Arg.IsAny<Expression<Func<CampingDB.Models.CampingPlace, bool>>>()), Occurs.Once());
        }

        [Test]
        public void ReturnSiteCategoryCampingPlaces_WhenProvidedCategoryNameIsValid()
        {
            // Arrange
            string categoryName = this.categoryName_01;
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingPlaceDataProvider(repository, unitOfWork);
            var expectedPlaces = this.GetCampingPlaces()
                .Where(p => p.SiteCategoriesNames.FirstOrDefault(s => s == categoryName) != null)
                .ToList();
            var dbPlaces = this.GetDbCampingPlaces()
                .Where(p => p.SiteCategories.FirstOrDefault(s => s.Name == categoryName) != null)
                .ToList();
            Mock.Arrange(() => repository.GetCampingPlaceRepository()
                .GetAll(p => (!p.IsDeleted) &&
                    (p.SiteCategories.FirstOrDefault(s => s.Name == categoryName) != null)))
                .Returns(dbPlaces);

            // Act
            var places = provider.GetSiteCategoryCampingPlaces(categoryName);

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
                    SiteCategoriesNames = new List<string>()
                    {
                        this.categoryName_01
                    }
                },
                new CampingPlace()
                {
                    Id = this.id_02,
                    Name = this.placeName_02,
                    SiteCategoriesNames = new List<string>()
                    {
                        this.categoryName_02
                    }
                },
                new CampingPlace()
                {
                    Id = this.id_03,
                    Name = this.placeName_03,
                    SiteCategoriesNames = new List<string>()
                    {
                        this.categoryName_01
                    }
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
                    AddedBy = Mock.Create<CampingDB.Models.CampingUser>(),
                    SiteCategories = new List<CampingDB.Models.SiteCategory>()
                    {
                        new CampingDB.Models.SiteCategory()
                            {
                                Name = this.categoryName_01
                            }
                    }
                },
                new CampingDB.Models.CampingPlace()
                {
                    Id = this.id_02,
                    Name = this.placeName_02,
                    AddedBy = Mock.Create<CampingDB.Models.CampingUser>(),
                    SiteCategories = new List<CampingDB.Models.SiteCategory>()
                    {
                        new CampingDB.Models.SiteCategory()
                            {
                                Name = this.categoryName_02
                            }
                    }
                },
                new CampingDB.Models.CampingPlace()
                {
                    Id = this.id_03,
                    Name = this.placeName_03,
                    AddedBy = Mock.Create<CampingDB.Models.CampingUser>(),
                    SiteCategories = new List<CampingDB.Models.SiteCategory>()
                    {
                        new CampingDB.Models.SiteCategory()
                            {
                                Name = this.categoryName_01
                            }
                    }
                }
            };

            return dbPlaces;
        }
    }
}
