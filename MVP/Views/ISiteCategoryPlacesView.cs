using MVP.Models;
using MVP.Models.EventModels;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface ISiteCategoryPlacesView : IView<SiteCategoryPlacesViewModel>
    {
        event EventHandler<NameEventArgs> SiteCategoryGetPlaces;
    }
}
