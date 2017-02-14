using CampingWebForms.Models;
using System;
using WebFormsMvp;

namespace CampingWebForms.Views
{
    public interface ISiteCategoriesView : IView<SiteCategoriesViewModel>
    {
        event EventHandler SiteCategoriesLoad;
    }
}
