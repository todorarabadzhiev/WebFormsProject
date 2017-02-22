using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using NUnit.Framework;
using Services.DataProviders;
using System;
using Telerik.JustMock;

namespace CampingWebForms.Tests.MVP.Presenters.MyCampingPlacesPresenterClass
{
    [TestFixture]
    public class View_MyCampingPlacesDeleteItem_Should
    {
        [Test]
        public void CallDeleteCampingPlaceMethodOfCampingPlaceProviderWithCorrectArgument_WhenMyCampingPlacesDeleteItemEventIsRaised()
        {
            // Arrange
            var view = Mock.Create<IMyCampingPlacesView>();
            var provider = Mock.Create<ICampingPlaceDataProvider>();
            MyCampingPlacesPresenter presenter = new MyCampingPlacesPresenter(view, provider);
            Guid id = Guid.NewGuid();

            // Act
            Mock.Raise(() => view.MyCampingPlacesDeleteItem += null, new IdEventArgs(id));

            // Assert
            Mock.Assert(() => provider.DeleteCampingPlace(id), Occurs.Once());
        }
    }
}
