using MVP.Models;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface IEditUsersView : IView<EditUsersViewModel>
    {
        event EventHandler EditUsersGetCampingUsers;
    }
}
