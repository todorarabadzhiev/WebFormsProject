using MVP.Models;
using MVP.Models.EventModels;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface ICampingPlaceDetailsView : IView<CampingPlaceDetailsViewModel>
    {
        event EventHandler<CampingPlaceDetailsEventArgs> CampingPlaceDetailsLoad;
    }
}
