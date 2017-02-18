using MVP.Models.EventModels;
using MVP.Views;
using Services.DataProviders;
using System;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class CreateUserPresenter : Presenter<ICreateUserView>
    {
        private readonly IDataProvider provider;
        public CreateUserPresenter(ICreateUserView view, IDataProvider provider)
            : base(view)
        {
            this.provider = provider;

            this.View.CreateUserClick += this.View_CreateUserClick;
        }

        private void View_CreateUserClick(object sender, CreateUserClickEventArgs e)
        {
            this.provider.AddCampingUser(e.ApplicationUserId, e.FirstName, e.LastName, e.UserName);
        }
    }
}
