using MVP.Models;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface ISiteCategoriesView : IView<SiteCategoriesViewModel>
    {
        event EventHandler SiteCategoriesLoad;
    }
}
