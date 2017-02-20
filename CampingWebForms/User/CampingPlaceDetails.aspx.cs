using CampingWebForms.Common;
using MVP.Models;
using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace User.CampingWebForms
{
    [PresenterBinding(typeof(CampingPlaceDetailsPresenter))]
    public partial class CampingPlaceDetails : MvpPage<CampingPlaceDetailsViewModel>, ICampingPlaceDetailsView
    {
        public event EventHandler<IdEventArgs> CampingPlaceDetailsLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid id = Guid.Parse(this.Request.QueryString["id"]);
                IdEventArgs args = new IdEventArgs(id);
                this.CampingPlaceDetailsLoad?.Invoke(sender, args);

                this.DetailsView.DataSource = this.Model.CampingPlaceDetails;
                this.DetailsView.DataBind();
            }
        }

        public string ConvertToImage(object data)
        {
            return Utilities.ConvertToImage((byte[])data);
        }
    }
}