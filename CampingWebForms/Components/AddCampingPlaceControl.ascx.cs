using CampingWebForms.Common;
using MVP.Models;
using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using System;
using System.Collections.Generic;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms.Components
{
    [PresenterBinding(typeof(AddCampingPlacePresenter))]
    public partial class AddCampingPlaceControl : MvpUserControl<AddCampingPlaceViewModel>, IAddCampingPlaceView
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

                this.ClearImageDataFromSession();
            }
        }

        protected void ButtonAddCampingPlace_Click(object sender, EventArgs e)
        {
            if (Session[Utilities.ImgUrls] != null)
            {
                string name = this.TextBoxName.Text;
                string addedBy = HttpContext.Current.User.Identity.Name;
                string description = this.TextBoxDescription.Text;
                string googleMapsUrl = this.TextBoxGoogleMapsUrl.Text;
                bool hasWater = this.CheckBoxHasWater.Checked;
                IEnumerable<string> siteCategoryNames = Utilities.GetSelectedItems(this.CheckBoxListCategories);
                IEnumerable<string> sightseeingNames = Utilities.GetSelectedItems(this.CheckBoxListSightseeing);

                IList<string> imageFileNames = this.MyAddImageControl.GetImageFileNames();
                IList<byte[]> imageFilesData = this.MyAddImageControl.GetImageFilesData(imageFileNames);

                AddCampingPlaceClickEventArgs args = new AddCampingPlaceClickEventArgs(
                    name, addedBy, description, googleMapsUrl, hasWater, sightseeingNames,
                    siteCategoryNames, imageFileNames, imageFilesData);
                this.AddCampingPlaceClick?.Invoke(sender, args);
                this.ClearImageDataFromSession();
                Response.Redirect("~/");
            }
            else
            {
                this.MyAddImageControl.ShowLblErrorMessage(true);
            }
        }

        private void ClearImageDataFromSession()
        {
            // clear previous image file data stored in Session
            if (Session[Utilities.ImgUrls] != null)
            {
                IList<string> imageFileUrls = this.MyAddImageControl.GetImageFileNames();
                foreach (var url in imageFileUrls)
                {
                    Session.Remove(url);
                }

                Session.Remove(Utilities.ImgUrls);
            }
        }
    }
}