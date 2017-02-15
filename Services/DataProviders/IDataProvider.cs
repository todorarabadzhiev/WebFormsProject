using Services.Models;
using System;
using System.Collections.Generic;

namespace Services.DataProviders
{
    public interface IDataProvider
    {
        //IEnumerable<CampingPlace> GetLatestCampingPlaces();
        IEnumerable<ICampingPlace> GetAllCampingPlaces();
        IEnumerable<ISiteCategory> GetAllSiteCategories();
        IEnumerable<ISightseeing> GetAllSightseeings();
        IEnumerable<ICampingPlace> GetCampingPlaceById(Guid id);
        void AddCampingPlace(string name, string description, string googleMapsUrl,
                bool hasWater, List<string> sightseeingNames, List<string> siteCategoryNames);
    }
}
