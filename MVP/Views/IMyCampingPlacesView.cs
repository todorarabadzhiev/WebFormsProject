using MVP.Models;
using MVP.Models.EventModels;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface IMyCampingPlacesView : IView<MyCampingPlacesViewModel>
    {
        event EventHandler<NameEventArgs> MyCampingPlacesGetData;
        event EventHandler<IdEventArgs> MyCampingPlacesDeleteItem;
    }
}
