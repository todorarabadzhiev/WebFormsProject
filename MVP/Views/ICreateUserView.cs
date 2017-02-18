using MVP.Models;
using MVP.Models.EventModels;
using System;
using WebFormsMvp;

namespace MVP.Views
{
    public interface ICreateUserView : IView<CreateUserViewModel>
    {
        event EventHandler<CreateUserClickEventArgs> CreateUserClick;
    }
}
