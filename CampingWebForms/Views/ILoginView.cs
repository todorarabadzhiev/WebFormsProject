using Auth;
using System;
using WebFormsMvp;

namespace CampingWebForms.Views
{
    public interface ILoginView : IView<ApplicationUser>
    {
        event EventHandler UserLogin;
    }
}
