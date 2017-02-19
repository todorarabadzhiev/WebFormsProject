﻿using MVP.Models.EventModels;
using MVP.Views;
using Services.DataProviders;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class CreateUserPresenter : Presenter<ICreateUserView>
    {
        private readonly ICampingUserDataProvider provider;
        public CreateUserPresenter(ICreateUserView view, ICampingUserDataProvider provider)
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
