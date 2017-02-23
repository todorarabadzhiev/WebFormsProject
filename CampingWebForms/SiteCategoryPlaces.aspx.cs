using CampingWebForms.Common;
using MVP.Models;
using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms
{
    [PresenterBinding(typeof(SiteCategoryPlacesPresenter))]
    public partial class SiteCategoryPlaces :  MvpPage<SiteCategoryPlacesViewModel>, ISiteCategoryPlacesView
    {
        public event EventHandler<NameEventArgs> SiteCategoryGetPlaces;
        public string CategoryName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CategoryName = this.Request.QueryString["name"];
                NameEventArgs args = new NameEventArgs(this.CategoryName);
                this.SiteCategoryGetPlaces?.Invoke(sender, args);
                this.ListViewSiteCategoryPlaces.DataSource = this.Model.CampingPlaces;
                this.ListViewSiteCategoryPlaces.DataBind();
            }
        }

        public string ConvertToImage(object data)
        {
            return Utilities.ConvertToImage((byte[])data);
        }
    }
}