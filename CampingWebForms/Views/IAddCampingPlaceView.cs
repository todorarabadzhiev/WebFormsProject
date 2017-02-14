using CampingWebForms.Models;
using System;
using WebFormsMvp;

namespace CampingWebForms.Views
{
    public interface IAddCampingPlaceView : IView<AddCampingPlaceViewModel>
    {
        event EventHandler AddCampingPlaceLoad;
        event EventHandler<AddCampingPlaceClickEventArgs> AddCampingPlaceClick;
    }
}
