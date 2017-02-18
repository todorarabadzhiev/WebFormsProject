using System;

namespace CampingWebForms.Common
{
    public static class Utilities
    {
        public static string ConvertToImage(byte[] fileData)
        {
            return "data:image/jpeg;base64," + Convert.ToBase64String(fileData);
        }
    }
}