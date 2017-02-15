using System;
using System.Collections.Generic;

namespace MVP.Models.EventModels
{
    public class AddCampingPlaceClickEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string GoogleMapsUrl { get; private set; }
        public bool HasWater { get; private set; }
        public List<string> SiteCategoryNames { get; private set; }
        public List<string> SightseeingNames { get; private set; }

        public AddCampingPlaceClickEventArgs(
            string name,
            string description,
            string googleMapsUrl,
            bool waterOnSite,
            List<string> sightseeingNames,
            List<string> siteCatgegoryNames)
        {
            this.Name = name;
            this.Description = description;
            this.GoogleMapsUrl = googleMapsUrl;
            this.HasWater = waterOnSite;
            this.SightseeingNames = sightseeingNames;
            this.SiteCategoryNames = siteCatgegoryNames;
        }
    }
}
