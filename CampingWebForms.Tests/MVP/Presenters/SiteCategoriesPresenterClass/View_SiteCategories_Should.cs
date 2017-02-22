using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.SiteCategoriesPresenterClass
{
    [TestFixture]
    public class View_SiteCategories_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();
        private Guid id_04 = Guid.NewGuid();

        private string categoryName_01 = "Name_01";
        private string categoryName_02 = "Name_02";
        private string categoryName_03 = "Name_03";
        private string categoryName_04 = "Name_04";

        [Test]
        public void AddCorrectSiteCategoriesToViewModel_WhenSiteCategoriesLoadEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<ISiteCategoriesView>();
            var provider = Mock.Create<ISiteCategoryDataProvider>();
            SiteCategoriesPresenter presenter = new SiteCategoriesPresenter(view, provider);
            var expectedSiteCategories = this.GetSiteCategories();

            Mock.Arrange(() => provider.GetAllSiteCategories()).Returns(expectedSiteCategories);

            // Act
            Mock.Raise(() => view.SiteCategoriesLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(expectedSiteCategories, view.Model.SiteCategories);
        }

        private IEnumerable<ISiteCategory> GetSiteCategories()
        {
            IEnumerable<ISiteCategory> categories = new List<ISiteCategory>()
            {
                new SiteCategory()
                {
                    Id = this.id_01,
                    Name = this.categoryName_01
                },
                new SiteCategory()
                {
                    Id = this.id_02,
                    Name = this.categoryName_02
                },
                new SiteCategory()
                {
                    Id = this.id_03,
                    Name = this.categoryName_03
                },
                new SiteCategory()
                {
                    Id = this.id_04,
                    Name = this.categoryName_04
                }
            };

            return categories;
        }
    }
}
