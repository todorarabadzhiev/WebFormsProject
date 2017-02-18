using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MVP.Models.EventModels
{
    public class AddCampingPlaceClickEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string GoogleMapsUrl { get; private set; }
        public bool HasWater { get; private set; }
        public IEnumerable<string> SiteCategoryNames { get; private set; }
        public IEnumerable<string> SightseeingNames { get; private set; }
        public IList<string> ImageFileNames { get; private set; }
        public IList<byte[]> ImageFilesData { get; private set; }

        public AddCampingPlaceClickEventArgs(
            string name,
            string description,
            string googleMapsUrl,
            bool waterOnSite,
            IEnumerable<string> sightseeingNames,
            IEnumerable<string> siteCatgegoryNames,
            IList<string> imageFileNames,
            IList<byte[]> imageFilesData)
        {
            this.Name = name;
            this.Description = description;
            this.GoogleMapsUrl = googleMapsUrl;
            this.HasWater = waterOnSite;
            this.SightseeingNames = sightseeingNames;
            this.SiteCategoryNames = siteCatgegoryNames;
            this.ImageFileNames = imageFileNames;
            this.ImageFilesData = imageFilesData;
        }
    }
}
