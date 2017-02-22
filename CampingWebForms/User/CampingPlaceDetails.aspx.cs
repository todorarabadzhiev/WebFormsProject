using CampingWebForms.Common;
using MVP.Models;
using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using System.Web.UI.WebControls;

namespace User.CampingWebForms
{
    [PresenterBinding(typeof(CampingPlaceDetailsPresenter))]
    public partial class CampingPlaceDetails : MvpPage<CampingPlaceDetailsViewModel>, ICampingPlaceDetailsView
    {
        public event EventHandler<IdEventArgs> CampingPlaceDetailsLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
                Guid id = Guid.Parse(this.Request.QueryString["id"]);
                IdEventArgs args = new IdEventArgs(id);
                this.CampingPlaceDetailsLoad?.Invoke(sender, args);

                this.DetailsView.DataSource = this.Model.CampingPlaceDetails;
                this.DetailsView.DataBind();
        }

        public string ConvertToImage(object data)
        {
            return Utilities.ConvertToImage((byte[])data);
        }

        //protected void LinkButtonEdit_Click(object sender, EventArgs e)
        //{
        //    this.DetailsView.ChangeMode(FormViewMode.Edit);
        //    this.MultiViewButtons.SetActiveView(this.ViewEditMode);
        //}

        //protected void LinkButtonSave_Click(object sender, EventArgs e)
        //{
        //    this.DetailsView.ChangeMode(FormViewMode.ReadOnly);
        //    this.MultiViewButtons.SetActiveView(this.ViewNormalMode);

        //    //TextBox textBoxPhone = (TextBox)
        //    //    this.DetailsView.FindControl("TextBoxPhone");
        //    //this.customers[customerIndex].Phone = textBoxPhone.Text;
        //    //TextBox textBoxEmail = (TextBox)
        //    //    this.DetailsView.FindControl("TextBoxEmail");
        //    //this.customers[customerIndex].Email = textBoxEmail.Text;
        //}

        //protected void LinkButtonCancel_Click(object sender, EventArgs e)
        //{
        //    this.DetailsView.ChangeMode(FormViewMode.ReadOnly);
        //    this.MultiViewButtons.SetActiveView(this.ViewNormalMode);
        //}
    }
}