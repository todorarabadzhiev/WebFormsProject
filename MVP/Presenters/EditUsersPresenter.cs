using MVP.Views;
using Services.DataProviders;
using System;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class EditUsersPresenter : Presenter<IEditUsersView>
    {
        private readonly ICampingUserDataProvider provider;
        public EditUsersPresenter(IEditUsersView view, ICampingUserDataProvider provider) 
            : base(view)
        {
            this.provider = provider;
            this.View.EditUsersGetCampingUsers += View_EditUsersGetCampingUsers;
        }

        private void View_EditUsersGetCampingUsers(object sender, EventArgs e)
        {
            this.View.Model.CampingUsers = this.provider.GetAllCampingUsers();
        }
    }
}
