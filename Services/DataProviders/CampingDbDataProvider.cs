using Repositories;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Services.DataProviders
{
    public class CampingDbDataProvider : IDataProvider
    {
        private readonly ICampingDBRepository repository;
        private readonly Func<IUnitOfWork> unitOfWork;

        public CampingDbDataProvider(ICampingDBRepository repository, Func<IUnitOfWork> unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("CampingDBRepository");
            }
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void AddCampingUser(string appUserId, string firstName, 
            string lastName, string userName)
        {
            IGenericRepository<CampingDB.Models.CampingUser> capmingUserRepository =
                this.repository.GetCampingUserRepository();
            ICampingUser newCampingUser = new CampingUser();
            newCampingUser.ApplicationUserId = appUserId;
            newCampingUser.FirstName = firstName;
            newCampingUser.LastName = lastName;
            newCampingUser.UserName = userName;

            using (var uw = this.unitOfWork())
            {
                CampingDB.Models.CampingUser dbCampingUser = ConvertFromUser(newCampingUser);
                capmingUserRepository.Add(dbCampingUser);
                uw.Commit();
            }
        }

        public void AddCampingPlace(
            string name, string description,
            string googleMapsUrl, bool hasWater,
            IEnumerable<string> sightseeingNames, IEnumerable<string> siteCategoryNames,
            IList<string> imageFileNames, IList<byte[]> imageFilesData)
        {
            IGenericRepository<CampingDB.Models.CampingPlace> capmingPlaceRepository =
                this.repository.GetCampingPlaceRepository();
            ICampingPlace newCampingPlace = new CampingPlace();
            newCampingPlace.Name = name;
            newCampingPlace.Description = description;
            newCampingPlace.GoogleMapsUrl = googleMapsUrl;
            newCampingPlace.HasWater = hasWater;
            newCampingPlace.SightseeingNames = sightseeingNames;
            newCampingPlace.SiteCategoriesNames = siteCategoryNames;

            using (var uw = this.unitOfWork())
            {
                CampingDB.Models.CampingPlace dbCampingPlace = ConvertFromPlace(newCampingPlace);
                dbCampingPlace.ImageFiles = GetImageFiles(imageFileNames, imageFilesData);
                capmingPlaceRepository.Add(dbCampingPlace);
                uw.Commit();
            }
        }

        public IEnumerable<ICampingPlace> GetCampingPlaceById(Guid id)
        {
            IGenericRepository<CampingDB.Models.CampingPlace> capmingPlaceRepository =
                this.repository.GetCampingPlaceRepository();
            var places = new List<ICampingPlace>();
            var dbPlace = capmingPlaceRepository.GetById(id);
            places.Add(ConvertToPlace(dbPlace));

            return places;
        }

        public IEnumerable<ICampingPlace> GetAllCampingPlaces()
        {
            IGenericRepository<CampingDB.Models.CampingPlace> capmingPlaceRepository =
                this.repository.GetCampingPlaceRepository();
            var places = new List<ICampingPlace>();
            var dbPlaces = capmingPlaceRepository.GetAll();
            foreach (var p in dbPlaces)
            {
                places.Add(ConvertToPlace(p));
            }

            return places;
        }

        public IEnumerable<ISiteCategory> GetAllSiteCategories()
        {
            IGenericRepository<CampingDB.Models.SiteCategory> siteCategoryRepository =
                this.repository.GetSiteCategoryRepository();
            var categories = new List<ISiteCategory>();
            var dbCategories = siteCategoryRepository.GetAll();
            foreach (var c in dbCategories)
            {
                categories.Add(ConvertToCategory(c));
            }

            return categories;
        }

        public IEnumerable<ISightseeing> GetAllSightseeings()
        {
            IGenericRepository<CampingDB.Models.Sightseeing> sightseeingRepository =
                this.repository.GetSightseeingRepository();
            var sightseeings = new List<ISightseeing>();
            var dbSightseeings = sightseeingRepository.GetAll();
            foreach (var s in dbSightseeings)
            {
                sightseeings.Add(ConvertToSightseeeing(s));
            }

            return sightseeings;
        }

        private ICollection<CampingDB.Models.ImageFile> GetImageFiles(IList<string> imageFileNames, IList<byte[]> imageFilesData)
        {
            if (imageFileNames == null || imageFilesData == null)
            {
                return null;
            }

            ICollection<CampingDB.Models.ImageFile> dbFiles = new List<CampingDB.Models.ImageFile>();
            for (int i = 0; i < imageFileNames.Count; i++)
            {
                CampingDB.Models.ImageFile dbFile = new CampingDB.Models.ImageFile();
                dbFile.FileName = imageFileNames[i];
                dbFile.Data = imageFilesData[i];

                dbFiles.Add(dbFile);
            }

            return dbFiles;
        }

        private CampingDB.Models.CampingUser ConvertFromUser(ICampingUser campUser)
        {
            CampingDB.Models.CampingUser user = new CampingDB.Models.CampingUser();
            user.ApplicationUserId = campUser.ApplicationUserId;
            user.FirstName = campUser.FirstName;
            user.LastName = campUser.LastName;
            user.UserName = campUser.UserName;
            user.RegisteredOn = DateTime.Now;

            return user;
        }

        private CampingDB.Models.CampingPlace ConvertFromPlace(ICampingPlace p)
        {
            CampingDB.Models.CampingPlace place = new CampingDB.Models.CampingPlace();
            place.Name = p.Name;
            place.Description = p.Description;
            place.GoogleMapsUrl = p.GoogleMapsUrl;
            place.WaterOnSite = p.HasWater;
            place.AddedOn = DateTime.Now;

            IGenericRepository<CampingDB.Models.Sightseeing> sightseeingRepository =
                this.repository.GetSightseeingRepository();
            IGenericRepository<CampingDB.Models.SiteCategory> siteCategoryRepository =
                this.repository.GetSiteCategoryRepository();
            place.Sightseeings = sightseeingRepository.GetAll(s => p.SightseeingNames.Contains(s.Name)).ToList();
            place.SiteCategories = siteCategoryRepository.GetAll(s => p.SiteCategoriesNames.Contains(s.Name)).ToList();

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
            foreach (var s in p.Sightseeings)
            {
                sightseeingIds.Add(s.Id);
                sightseeingNames.Add(s.Name);
            }

            place.SiteCategoriesIds = sightseeingIds;
            place.SightseeingNames = sightseeingNames;

            List<Guid> siteCategoriesIds = new List<Guid>();
            List<string> siteCategoriesNames = new List<string>();
            foreach (var c in p.SiteCategories)
            {
                siteCategoriesIds.Add(c.Id);
                siteCategoriesNames.Add(c.Name);
            }

            place.SiteCategoriesIds = siteCategoriesIds;
            place.SiteCategoriesNames = siteCategoriesNames;

            List<string> imgFileNames = new List<string>();
            List<byte[]> imgFilesData = new List<byte[]>();
            var imgRepository = repository.GetImageFileRepository();
            var dbImages = imgRepository.GetAll(img => img.CampingPlaceId == p.Id);
            List<IImageFile> imageFiles = new List<IImageFile>();
            foreach (var dbImg in dbImages)
            {
                IImageFile img = new ImageFile();
                img.CampingPlaceId = dbImg.CampingPlaceId;
                img.Data = dbImg.Data;
                img.FileName = dbImg.FileName;
                imageFiles.Add(img);
            }

            place.ImageFiles = imageFiles;

            return place;
        }

        private ISiteCategory ConvertToCategory(CampingDB.Models.SiteCategory c)
        {
            ISiteCategory category = new SiteCategory();
            category.Name = c.Name;
            category.Id = c.Id;

            return category;
        }

        private ISightseeing ConvertToSightseeeing(CampingDB.Models.Sightseeing s)
        {
            ISightseeing sightseeing = new Sightseeing();
            sightseeing.Name = s.Name;
            sightseeing.Id = s.Id;

            return sightseeing;
        }
    }
}