using CampingWebForms.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace CampingWebForms.Components
{
    public partial class CampingPlaceImagesControl : System.Web.UI.UserControl
    {
        protected void AddImageButton_Click(object sender, EventArgs e)
        {
            if (this.ImgFileUpload.HasFile)
            {
                this.LblErrorMessage.Visible = false;
                string fileUrl = this.ImgFileUpload.FileName;
                Session[Utilities.ImgUrls] += fileUrl + Utilities.Separator;

                int length = this.ImgFileUpload.PostedFile.ContentLength;
                byte[] fileData = new byte[length + 1];
                Stream fileStream = this.ImgFileUpload.PostedFile.InputStream;
                fileStream.Read(fileData, 0, length);
                Session[fileUrl] = fileData;

                this.ShowUploadedImageFiles();
            }
        }

        protected void UploadedImgFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            string imgNames = (string)Session[Utilities.ImgUrls];
            List<string> imgNamesList = imgNames.Split(Utilities.Separator).ToList();
            imgNamesList.RemoveAt(index);
            string updatedImgNames = string.Join(Utilities.Separator.ToString(), imgNamesList);
            Session[Utilities.ImgUrls] = updatedImgNames;

            this.ShowUploadedImageFiles();
        }

        public void ShowLblErrorMessage(bool value)
        {
            this.LblErrorMessage.Visible = value;
        }

        private void ShowUploadedImageFiles()
        {
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

        public IList<string> GetImageFileNames()
        {
            if (Session[Utilities.ImgUrls] == null)
            {
                return null;
            }

            string urlsFromSession = (string)Session[Utilities.ImgUrls];
            IList<string> imageFileUrls = urlsFromSession.Split(Utilities.Separator).ToList();
            imageFileUrls.RemoveAt(imageFileUrls.Count - 1);

            return imageFileUrls;
        }

        public IList<byte[]> GetImageFilesData(IList<string> imageFileUrls)
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
    }
}