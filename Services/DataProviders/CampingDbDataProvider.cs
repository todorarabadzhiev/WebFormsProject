using CampingDB;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.DataProviders
{
    public class CampingDbDataProvider : IDataProvider
    {
        private readonly CampingDBContext dbContext;
        public CampingDbDataProvider(CampingDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddCampingPlace(
            string name, string description,
            string googleMapsUrl, bool hasWater,
            List<string> sightseeingNames, List<string> siteCategoryNames)
        {
            ICampingPlace newCampingPlace = new CampingPlace();
            newCampingPlace.Name = name;
            newCampingPlace.Description = description;
            newCampingPlace.GoogleMapsUrl = googleMapsUrl;
            newCampingPlace.HasWater = hasWater;
            newCampingPlace.SightseeingNames = sightseeingNames;
            newCampingPlace.SiteCategoriesNames = siteCategoryNames;

            CampingDB.Models.CampingPlace dbCampingPlace = convertFromPlace(newCampingPlace);
            this.dbContext.CampingPlaces.Add(dbCampingPlace);
            dbContext.SaveChanges();
        }

        public IEnumerable<ICampingPlace> GetCampingPlaceById(Guid id)
        {
            var places = new List<ICampingPlace>();
            var dbPlace = this.dbContext.CampingPlaces.Where(p => p.Id == id).ToList();
            foreach (var p in dbPlace)
            {
                places.Add(ConvertToPlace(p));
            }

            return places;
        }

        public IEnumerable<ICampingPlace> GetAllCampingPlaces()
        {
            var places = new List<ICampingPlace>();
            var dbPlaces = this.dbContext.CampingPlaces.ToList();
            foreach (var p in dbPlaces)
            {
                places.Add(ConvertToPlace(p));
            }

            return places;
        }

        public IEnumerable<ISiteCategory> GetAllSiteCategories()
        {
            var categories = new List<ISiteCategory>();
            var dbCategories = this.dbContext.SiteCategories.ToList();
            foreach (var c in dbCategories)
            {
                categories.Add(ConvertToCategory(c));
            }

            return categories;
        }

        public IEnumerable<ISightseeing> GetAllSightseeings()
        {
            var sightseeings = new List<ISightseeing>();
            var dbSightseeings = this.dbContext.Sightseeings.ToList();
            foreach (var s in dbSightseeings)
            {
                sightseeings.Add(ConvertToSightseeeing(s));
            }

            return sightseeings;
        }

        private ISightseeing ConvertToSightseeeing(CampingDB.Models.Sightseeing s)
        {
            ISightseeing sightseeing = new Sightseeing();
            sightseeing.Name = s.Name;
            sightseeing.Id = s.Id;
            sightseeing.Type = s.Type.Name;

            return sightseeing;
        }

        private CampingDB.Models.CampingPlace convertFromPlace(ICampingPlace p)
        {
            CampingDB.Models.CampingPlace place = new CampingDB.Models.CampingPlace();
            place.Name = p.Name;
            place.Description = p.Description;
            place.GoogleMapsUrl = p.GoogleMapsUrl;
            place.WaterOnSite = p.HasWater;
            place.AddedOn = DateTime.Now;

            place.Sightseeings = dbContext.Sightseeings
                    .Where(s => p.SightseeingNames.Contains(s.Name))
                    .ToList();
            place.SiteCategories = dbContext.SiteCategories
                    .Where(s => p.SiteCategoriesNames.Contains(s.Name))
                    .ToList();

            return place;
        }

        private ICampingPlace ConvertToPlace(CampingDB.Models.CampingPlace p)
        {
            ICampingPlace place = new CampingPlace();
            place.Name = p.Name;
            place.Id = p.Id;
            place.Description = p.Description;
            place.GoogleMapsUrl = p.GoogleMapsUrl;
            place.HasWater = p.WaterOnSite;

            List<Guid> sightseeingIds = new List<Guid>();
            List<string> sightseeingNames = new List<string>();
            List<string> sightseeingTypes = new List<string>();
            foreach (var s in p.Sightseeings)
            {
                sightseeingIds.Add(s.Id);
                sightseeingNames.Add(s.Name);
                sightseeingTypes.Add(s.Type.Name);
            }

            place.SiteCategoriesIds = sightseeingIds;
            place.SightseeingNames = sightseeingNames;
            place.SightseeingTypes = sightseeingTypes;

            List<Guid> siteCategoriesIds = new List<Guid>();
            List<string> siteCategoriesNames = new List<string>();
            foreach (var c in p.SiteCategories)
            {
                siteCategoriesIds.Add(c.Id);
                siteCategoriesNames.Add(c.Name);
            }

            place.SiteCategoriesIds = siteCategoriesIds;
            place.SiteCategoriesNames = siteCategoriesNames;

            return place;
        }

        private ISiteCategory ConvertToCategory(CampingDB.Models.SiteCategory c)
        {
            ISiteCategory category = new SiteCategory();
            category.Name = c.Name;
            category.Id = c.Id;

            return category;
        }
    }
}