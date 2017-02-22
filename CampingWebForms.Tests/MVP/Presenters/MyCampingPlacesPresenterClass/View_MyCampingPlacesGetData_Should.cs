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

namespace CampingWebForms.Tests.MVP.Presenters.MyCampingPlacesPresenterClass
{
    [TestFixture]
    public class View_MyCampingPlacesGetData_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();
        private Guid id_04 = Guid.NewGuid();

        private string placeName_01 = "Name_01";
        private string placeName_02 = "Name_02";
        private string placeName_03 = "Name_03";
        private string placeName_04 = "Name_04";

        private string userName_01 = "User_01";
        private string userName_02 = "User_02";
        private string userName_04 = "User_04";

        [Test]
        public void AddCorrectMyCampingPlacesToViewModel_WhenMyCampingPlacesGetDataEventIsRaised()
        {
            // Arrange
            string userName = this.userName_01;
            var view = Mock.Create<IMyCampingPlacesView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();
            MyCampingPlacesPresenter presenter = new MyCampingPlacesPresenter(view, provider);
            var expectedPlaces = this.GetCampingPlaces()
                .Where(p => p.AddedBy == userName)
                .ToList();

            Mock.Arrange(() => provider.GetUserCampingPlaces(userName)).Returns(expectedPlaces);

            // Act
            Mock.Raise(() => view.MyCampingPlacesGetData += null, new NameEventArgs(userName));

            // Assert
            CollectionAssert.AreEquivalent(expectedPlaces, view.Model.MyCampingPlaces);
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
                },
                new CampingPlace()
                {
                    Id = this.id_04,
                    Name = this.placeName_04,
                    AddedBy = this.userName_04
                }
            };

            return places;
        }
    }
}
