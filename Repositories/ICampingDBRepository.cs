﻿using CampingDB.Models;

namespace Repositories
{
    public interface ICampingDBRepository
    {
        IGenericRepository<CampingPlace> GetCampingPlaceRepository();
        IGenericRepository<SiteCategory> GetSiteCategoryRepository();
        IGenericRepository<Sightseeing> GetSightseeingRepository();
    }
}