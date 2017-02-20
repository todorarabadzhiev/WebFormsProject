using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms.Admin
{
    [PresenterBinding(typeof(EditUsersPresenter))]
    public partial class EditUsers : MvpPage<EditUsersViewModel>, IEditUsersView
    {
        public event EventHandler EditUsersGetCampingUsers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.EditUsersGetCampingUsers?.Invoke(sender, e);
                this.EditUsersContol.DataSource = this.Model.CampingUsers;
                this.EditUsersContol.DataBind();
            }
        }

        protected void EditUsersContol_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.EditUsersContol.PageIndex = e.NewPageIndex;

            //this.EditUsersGetCampingUsers?.Invoke(sender, e);
            this.EditUsersContol.DataSource = this.Model.CampingUsers;
            this.EditUsersContol.DataBind();
        }
    }
}