using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.SiteCategoryPlacesPresenterClass
{
    [TestFixture]
    public class View_SiteCategoryGetPlaces_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();
        private Guid id_04 = Guid.NewGuid();

        private string placeName_01 = "Name_01";
        private string placeName_02 = "Name_02";
        private string placeName_03 = "Name_03";
        private string placeName_04 = "Name_04";

        private string categoryName_01 = "Category_01";
        private string categoryName_02 = "Category_02";
        private string categoryName_04 = "Category_04";

        [Test]
        public void AddCorrectMyCampingPlacesToViewModel_WhenMyCampingPlacesGetDataEventIsRaised()
        {
            // Arrange
            string categoryName = this.categoryName_01;
            var view = Mock.Create<ISiteCategoryPlacesView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();
            SiteCategoryPlacesPresenter presenter = new SiteCategoryPlacesPresenter(view, provider);
            var expectedPlaces = this.GetCampingPlaces()
                .Where(p => p.SiteCategoriesNames.FirstOrDefault(s => s == categoryName) != null)
                .ToList();

            Mock.Arrange(() => provider.GetSiteCategoryCampingPlaces(categoryName)).Returns(expectedPlaces);

            // Act
            Mock.Raise(() => view.SiteCategoryGetPlaces += null, new NameEventArgs(categoryName));

            // Assert
            CollectionAssert.AreEquivalent(expectedPlaces, view.Model.CampingPlaces);
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
                },
                new CampingPlace()
                {
                    Id = this.id_04,
                    Name = this.placeName_04,
                    SiteCategoriesNames = new List<string>()
                    {
                        this.categoryName_04
                    }
                }
            };

            return places;
        }
    }
}
