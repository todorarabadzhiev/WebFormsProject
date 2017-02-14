using CampingWebForms.Models;
using CampingWebForms.Presenters;
using CampingWebForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms
{
    [PresenterBinding(typeof(AddCampingPlacePresenter))]
    public partial class AddCampingPlace : MvpPage<AddCampingPlaceViewModel>, IAddCampingPlaceView
    {
        public event EventHandler AddCampingPlaceLoad;
        public event EventHandler<AddCampingPlaceClickEventArgs> AddCampingPlaceClick;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.AddCampingPlaceLoad?.Invoke(sender, e);
                this.CheckBoxListCategories.DataSource = this.Model.SiteCategories;
                this.CheckBoxListCategories.DataBind();
                this.CheckBoxListSightseeing.DataSource = this.Model.Sightseeings;
                this.CheckBoxListSightseeing.DataBind();
            }
        }

        protected void ButtonAddCampingPlace_Click(object sender, EventArgs e)
        {
            string name = this.TextBoxName.Text;
            string description = this.TextBoxDescription.Text;
            string googleMapsUrl = this.TextBoxGoogleMapsUrl.Text;
            bool hasWater = this.CheckBoxHasWater.Checked;
            List<string> siteCategoryNames = this.GetSelectedItems(this.CheckBoxListCategories);
            List<string> sightseeingNames = this.GetSelectedItems(this.CheckBoxListSightseeing);

            AddCampingPlaceClickEventArgs args = new AddCampingPlaceClickEventArgs(
                name, description, googleMapsUrl,hasWater, sightseeingNames, siteCategoryNames);
            this.AddCampingPlaceClick?.Invoke(sender, args);
        }

        private List<string> GetSelectedItems(CheckBoxList checkBoxList)
        {
            List<string> checkBoxListValues = checkBoxList.Items.Cast<ListItem>()
               .Where(li => li.Selected)
               .Select(li => li.Value)
               .ToList();

            return checkBoxListValues;
        }
    }
}