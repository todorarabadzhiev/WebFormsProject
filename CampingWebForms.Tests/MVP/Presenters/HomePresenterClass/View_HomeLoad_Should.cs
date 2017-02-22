using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.HomePresenterClass
{
    [TestFixture]
    public class View_HomeLoad_Should
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
        private string userName_03 = "User_03";
        private string userName_04 = "User_04";

        private DateTime date_01 = new DateTime(2000, 1, 1);
        private DateTime date_02 = new DateTime(2005, 1, 1);
        private DateTime date_03 = new DateTime(2010, 1, 1);
        private DateTime date_04 = new DateTime(2007, 1, 1);

        public void AddCorrectCampingPlacesToViewModel_WhenHomeLoadEventIsRaised()
        {
            // Arrange
            int count = 3;
            var view = Mock.Create<IHomeView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();
            HomePresenter presenter = new HomePresenter(view, provider);
            var expectedPlaces = this.GetCampingPlaces().OrderByDescending(p => p.AddedOn).ToList();
            // Get the required number
            while (expectedPlaces.Count > count)
            {
                expectedPlaces.RemoveAt(expectedPlaces.Count - 1);
            }

            // Get in reverse order
            for (int i = 0; i < expectedPlaces.Count / 2; i++)
            {
                var temp = expectedPlaces[i];
                expectedPlaces[i] = expectedPlaces[expectedPlaces.Count - i - 1];
                expectedPlaces[expectedPlaces.Count - i - 1] = temp;
            }

            Mock.Arrange(() => provider.GetLatestCampingPlaces(count)).Returns(expectedPlaces);

            // Act
            Mock.Raise(() => view.HomeLoad += null, EventArgs.Empty);

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
                    AddedBy = this.userName_01,
                    AddedOn = this.date_01
                },
                new CampingPlace()
                {
                    Id = this.id_02,
                    Name = this.placeName_02,
                    AddedBy = this.userName_02,
                    AddedOn = this.date_02
                },
                new CampingPlace()
                {
                    Id = this.id_03,
                    Name = this.placeName_03,
                    AddedBy = this.userName_03,
                    AddedOn = this.date_03
                },
                new CampingPlace()
                {
                    Id = this.id_04,
                    Name = this.placeName_04,
                    AddedBy = this.userName_04,
                    AddedOn = this.date_04
                }
            };

            return places;
        }
    }
}
