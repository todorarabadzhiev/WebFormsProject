using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.AddCampingPlacePresenterClass
{
    [TestFixture]
    public class View_AddCampingPlaceLoad_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();

        private string name_01 = "Name_01";
        private string name_02 = "Name_02";
        private string name_03 = "Name_03";

        [Test]
        public void AddCorrectSiteCategoriesToViewModel_WhenAddCampingPlaceLoadEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<IAddCampingPlaceView>();
            var campingPlaceProvider = Mock.Create<ICampingPlaceDataProvider>();
            var sightseeingProvider = Mock.Create<ISightseeingDataProvider>();
            var siteCategoryProvider = Mock.Create<ISiteCategoryDataProvider>();
            var siteCategories = this.GetSiteCategories();
            Mock.Arrange(() => siteCategoryProvider.GetAllSiteCategories()).Returns(siteCategories);
            AddCampingPlacePresenter presenter = new AddCampingPlacePresenter(view,
                campingPlaceProvider, sightseeingProvider, siteCategoryProvider);

            // Act
            Mock.Raise(() => view.AddCampingPlaceLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(siteCategories, view.Model.SiteCategories);
        }

        public void AddCorrectSightseeingsToViewModel_WhenAddCampingPlaceLoadEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<IAddCampingPlaceView>();
            var campingPlaceProvider = Mock.Create<ICampingPlaceDataProvider>();
            var sightseeingProvider = Mock.Create<ISightseeingDataProvider>();
            var siteCategoryProvider = Mock.Create<ISiteCategoryDataProvider>();
            var sightseeings = this.GetSightseeings();
            Mock.Arrange(() => sightseeingProvider.GetAllSightseeings()).Returns(sightseeings);
            AddCampingPlacePresenter presenter = new AddCampingPlacePresenter(view,
                campingPlaceProvider, sightseeingProvider, siteCategoryProvider);

            // Act
            Mock.Raise(() => view.AddCampingPlaceLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(sightseeings, view.Model.Sightseeings);
        }

        private IEnumerable<ISightseeing> GetSightseeings()
        {
            IEnumerable<ISightseeing> sightseeings =
                new List<ISightseeing>()
            {
                new Sightseeing()
                {
                    Id = this.id_01,
                    Name = this.name_01
                },
                new Sightseeing()
                {
                    Id = this.id_02,
                    Name = this.name_02
                },
                new Sightseeing()
                {
                    Id = this.id_03,
                    Name = this.name_03
                }
            };

            return sightseeings;
        }

        private IEnumerable<ISiteCategory> GetSiteCategories()
        {
            IEnumerable<ISiteCategory> siteCategories =
                new List<ISiteCategory>()
            {
                new SiteCategory()
                {
                    Id = this.id_01,
                    Name = this.name_01
                },
                new SiteCategory()
                {
                    Id = this.id_02,
                    Name = this.name_02
                },
                new SiteCategory()
                {
                    Id = this.id_03,
                    Name = this.name_03
                }
            };

            return siteCategories;
        }
    }
}
