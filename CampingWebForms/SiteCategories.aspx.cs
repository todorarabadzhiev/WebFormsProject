using CampingWebForms.Models;
using CampingWebForms.Presenters;
using CampingWebForms.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms
{
    [PresenterBinding(typeof(SiteCategoriesPresenter))]
    public partial class SiteCategories : MvpPage<SiteCategoriesViewModel>, ISiteCategoriesView
    {
        public event EventHandler SiteCategoriesLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SiteCategoriesLoad?.Invoke(sender, e);
            this.ListViewSiteCategories.DataSource = this.Model.SiteCategories;
            this.ListViewSiteCategories.DataBind();
        }
    }
}