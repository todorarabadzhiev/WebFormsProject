using MVP.Views;
using Services.DataProviders;
using System;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class SiteCategoriesPresenter : Presenter<ISiteCategoriesView>
    {
        protected readonly ISiteCategoryDataProvider provider;

        public SiteCategoriesPresenter(ISiteCategoriesView view, ISiteCategoryDataProvider provider)
            : base(view)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("SiteCategoryProvider");
            }

            this.provider = provider;

            this.View.SiteCategoriesLoad += this.View_SiteCategories;
        }

        private void View_SiteCategories(object sender, EventArgs e)
        {
            this.View.Model.SiteCategories = this.provider.GetAllSiteCategories();
        }
    }
}
