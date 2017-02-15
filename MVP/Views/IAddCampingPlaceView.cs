using MVP.Models;
using MVP.Models.EventModels;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface IAddCampingPlaceView : IView<AddCampingPlaceViewModel>
    {
        event EventHandler AddCampingPlaceLoad;
        event EventHandler<AddCampingPlaceClickEventArgs> AddCampingPlaceClick;
    }
}
