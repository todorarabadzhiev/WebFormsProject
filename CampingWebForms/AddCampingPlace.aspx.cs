using CampingWebForms.Common;
using MVP.Models;
using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms
{
    [PresenterBinding(typeof(AddCampingPlacePresenter))]
    public partial class AddCampingPlace : MvpPage<AddCampingPlaceViewModel>, IAddCampingPlaceView
    {
        const char Separator = ',';
        const string ImgUrls = "ImageFileUrls";

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

                // clear previous image file data stored in Session
                if (Session[ImgUrls] != null)
                {
                    IList<string> imageFileUrls = this.GetImageFileNames();
                    foreach (var url in imageFileUrls)
                    {
                        Session.Remove(url);
                    }

                    Session.Remove(ImgUrls);
                }
            }
        }

        protected void ButtonAddCampingPlace_Click(object sender, EventArgs e)
        {
            if (Session[ImgUrls] != null)
            {
                string name = this.TextBoxName.Text;
                string description = this.TextBoxDescription.Text;
                string googleMapsUrl = this.TextBoxGoogleMapsUrl.Text;
                bool hasWater = this.CheckBoxHasWater.Checked;
                IEnumerable<string> siteCategoryNames = this.GetSelectedItems(this.CheckBoxListCategories);
                IEnumerable<string> sightseeingNames = this.GetSelectedItems(this.CheckBoxListSightseeing);

                IList<string> imageFileNames = this.GetImageFileNames();
                IList<byte[]> imageFilesData = this.GetImageFilesData(imageFileNames);

                AddCampingPlaceClickEventArgs args = new AddCampingPlaceClickEventArgs(
                    name, description, googleMapsUrl, hasWater, sightseeingNames,
                    siteCategoryNames, imageFileNames, imageFilesData);
                this.AddCampingPlaceClick?.Invoke(sender, args);
                Response.Redirect("~/");
            }
            else
            {
                this.LblErrorMessage.Visible = true;
            }
        }

        protected void AddImageButton_Click(object sender, EventArgs e)
        {
            if (this.ImgFileUpload.HasFile)
            {
                this.LblErrorMessage.Visible = false;
                string fileUrl = this.ImgFileUpload.FileName;
                Session[ImgUrls] += fileUrl + Separator;

                int length = this.ImgFileUpload.PostedFile.ContentLength;
                byte[] fileData = new byte[length + 1];
                Stream fileStream = this.ImgFileUpload.PostedFile.InputStream;
                fileStream.Read(fileData, 0, length);
                Session[fileUrl] = fileData;

                // Show uploaded data in Repeater
                IList<string> fileList = this.GetImageFileNames();
                IList<byte[]> filesData = this.GetImageFilesData(fileList);
                var itemData = new[] { new { Name = fileList[0], Data = Utilities.ConvertToImage(filesData[0]) } }.ToList();
                for (int i = 1; i < fileList.Count; i++)
                {
                    string name = fileList[i];
                    byte[] data = filesData[i];

                    itemData.Add(new { Name = name, Data = Utilities.ConvertToImage(data) });
                }
                this.FilesCount.InnerText = string.Format("Добавени {0} изображения:", fileList.Count);
                this.UploadedImgFiles.DataSource = itemData;
                this.UploadedImgFiles.DataBind();
            }
        }

        private IList<string> GetImageFileNames()
        {
            if (Session[ImgUrls] == null)
            {
                return null;
            }

            string urlsFromSession = (string)Session[ImgUrls];
            IList<string> imageFileUrls = urlsFromSession.Split(Separator).ToList();
            imageFileUrls.RemoveAt(imageFileUrls.Count - 1);

            return imageFileUrls;
        }

        private IList<byte[]> GetImageFilesData(IList<string> imageFileUrls)
        {
            if (imageFileUrls == null)
            {
                return null;
            }

            IList<byte[]> imgFilesData = new List<byte[]>();
            foreach (var url in imageFileUrls)
            {
                var fileData = (byte[])Session[url];
                imgFilesData.Add(fileData);
            }

            return imgFilesData;
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