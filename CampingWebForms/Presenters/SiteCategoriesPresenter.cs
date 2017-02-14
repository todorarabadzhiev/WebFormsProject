using CampingWebForms.Services;
using CampingWebForms.Views;
using System;
using WebFormsMvp;

namespace CampingWebForms.Presenters
{
    public class SiteCategoriesPresenter : Presenter<ISiteCategoriesView>
    {
        private readonly IDataProvider provider;
        public SiteCategoriesPresenter(ISiteCategoriesView view, IDataProvider provider)
            : base(view)
        {
            this.provider = provider;

            this.View.SiteCategoriesLoad += this.View_SiteCategories;
        }

        private void View_SiteCategories(object sender, EventArgs e)
        {
            this.View.Model.SiteCategories = this.provider.GetAllSiteCategories();
        }
    }
}