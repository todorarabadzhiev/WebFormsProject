using MVP.Models;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface IHomeView : IView<HomeViewModel>
    {
        event EventHandler HomeLoad;
    }
}
