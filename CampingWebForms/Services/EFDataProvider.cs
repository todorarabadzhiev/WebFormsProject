using System;
using System.Collections.Generic;

namespace CampingWebForms.Services
{
    public class EFDataProvider : IDataProvider
    {
        //private readonly ICampingDBRepository repository;
        //public EFDataProvider(ICampingDBRepository repository)
        //{
        //    if (repository == null)
        //    {
        //        throw new ArgumentNullException("CampingDBRepository");
        //    }

        //    this.repository = repository;
        //}
        //public IEnumerable<ICampingPlace> GetAllCampingPlaces()
        //{
        //    var placesRepository = this.repository.GetCampingPlaceRepository();
        //    IEnumerable<CampingDB.Models.CampingPlace> dbPlaces = placesRepository.GetAll();

        //    IEnumerable<ICampingPlace> places = dbPlaces
        //        .Select(p => ConvertCampingPlace(p))
        //        .ToList();

        //    return places;
        //}

        //private ICampingPlace ConvertCampingPlace(CampingDB.Models.CampingPlace p)
        //{
        //    ICampingPlace place = new CampingPlace();
        //    place.Name = p.Name;

        //    return place;
        //}

        //public IEnumerable<ISiteCategory> GetAllSiteCategories()
        //{
        //    var siteRepository = this.repository.GetSiteCategoryRepository();
        //    IEnumerable<CampingDB.Models.SiteCategory> dbCategories = siteRepository.GetAll();

        //    IEnumerable<ISiteCategory> categories = dbCategories
        //        .Select(c => ConvertSiteCategory(c))
        //        .ToList();

        //    return categories;
        //}

        //private ISiteCategory ConvertSiteCategory(CampingDB.Models.SiteCategory c)
        //{
        //    ISiteCategory category = new SiteCategory();
        //    category.Name = c.Name;

        //    return category;
        //}
        public IEnumerable<ICampingPlace> GetAllCampingPlaces()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISiteCategory> GetAllSiteCategories()
        {
            throw new NotImplementedException();
        }
    }
}
