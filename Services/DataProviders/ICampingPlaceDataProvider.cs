using Services.Models;
using System;
using System.Collections.Generic;

namespace Services.DataProviders
{
    public interface ICampingPlaceDataProvider
    {
        IEnumerable<ICampingPlace> GetAllCampingPlaces();
        IEnumerable<ICampingPlace> GetLatestCampingPlaces(int count);
        IEnumerable<ICampingPlace> GetCampingPlaceById(Guid id);
        void AddCampingPlace(string name, string description, string googleMapsUrl,
                bool hasWater, IEnumerable<string> sightseeingNames, IEnumerable<string> siteCategoryNames,
                IList<string> imageFileNames, IList<byte[]> imageFiles);
    }
}
