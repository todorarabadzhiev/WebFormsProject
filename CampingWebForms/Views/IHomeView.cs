using CampingWebForms.Models;
using System;
using WebFormsMvp;

namespace CampingWebForms.Views
{
    public interface IHomeView : IView<HomeViewModel>
    {
        event EventHandler HomeLoad;
    }
}
