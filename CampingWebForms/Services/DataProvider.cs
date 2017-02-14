using System;
using System.Collections.Generic;

namespace CampingWebForms.Services
{
    public class DataProvider : IDataProvider
    {
        public IEnumerable<ICampingPlace> GetAllCampingPlaces()
        {
            var p1 = new CampingPlace();
            p1.Name = "Latest Place 01";
            var p2 = new CampingPlace();
            p2.Name = "Latest Place 02";
            var p3 = new CampingPlace();
            p3.Name = "Latest Place 03";
            List<ICampingPlace> latestCampingPlaces = new List<ICampingPlace>() { p1, p2, p3 };

            return latestCampingPlaces;
        }

        public IEnumerable<ISiteCategory> GetAllSiteCategories()
        {
            var c1 = new SiteCategory();
            c1.Name = "Море";
            var c2 = new SiteCategory();
            c2.Name = "Гора";
            var c3 = new SiteCategory();
            c3.Name = "Планина";
            var c4 = new SiteCategory();
            c4.Name = "Река";
            List<ISiteCategory> siteCategories = new List<ISiteCategory>() { c1, c2, c3, c4 };

            return siteCategories;
        }

        public ICampingPlace GetCampingPlaceById(string id)
        {
            throw new NotImplementedException();
        }
    }
}