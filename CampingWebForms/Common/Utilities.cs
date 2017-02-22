using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace CampingWebForms.Common
{
    public static class Utilities
    {
        public const char Separator = ',';
        public const string ImgUrls = "ImageFileUrls";

        public static string ConvertToImage(byte[] fileData)
        {
            return "data:image/jpeg;base64," + Convert.ToBase64String(fileData);
        }

        public static List<string> GetSelectedItems(CheckBoxList checkBoxList)
        {
            List<string> checkBoxListValues = checkBoxList.Items.Cast<ListItem>()
               .Where(li => li.Selected)
               .Select(li => li.Value)
               .ToList();

            return checkBoxListValues;
        }
    }
}