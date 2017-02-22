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

namespace CampingWebForms.Tests.MVP.Presenters.CampingPlaceDetailsPresenterClass
{
    [TestFixture]
    public class View_CampingPlaceDetailsLoad_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();

        private string name_01 = "Name_01";
        private string name_02 = "Name_02";
        private string name_03 = "Name_03";

        [Test]
        public void AddCorrectCampingPlaceToViewModel_WhenCampingPlaceDetailsLoadEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<ICampingPlaceDetailsView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();
            CampingPlaceDetailsPresenter presenter = new CampingPlaceDetailsPresenter(view, provider);
            Guid id = this.id_01;
            var places = this.GetCampingPlaces().Where(p => p.Id == id).ToList();
            Mock.Arrange(() => provider.GetCampingPlaceById(id)).Returns(places);

            // Act
            Mock.Raise(() => view.CampingPlaceDetailsLoad += null, new IdEventArgs(id));

            // Assert
            CollectionAssert.AreEquivalent(places, view.Model.CampingPlaceDetails);
        }

        private IEnumerable<ICampingPlace> GetCampingPlaces()
        {
            IEnumerable<ICampingPlace> campingPlaces =
                new List<ICampingPlace>()
            {
                new CampingPlace()
                {
                    Id = this.id_01,
                    Name = this.name_01
                },
                new CampingPlace()
                {
                    Id = this.id_02,
                    Name = this.name_02
                },
                new CampingPlace()
                {
                    Id = this.id_03,
                    Name = this.name_03
                }
            };

            return campingPlaces;
        }
    }
}
