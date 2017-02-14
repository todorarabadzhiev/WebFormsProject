using CampingWebForms.Models;
using System;
using WebFormsMvp;

namespace CampingWebForms.Views
{
    public interface ICampingPlaceDetailsView : IView<CampingPlaceDetailsViewModel>
    {
        event EventHandler<CampingPlaceDetailsEventArgs> CampingPlaceDetailsLoad;
    }
}
