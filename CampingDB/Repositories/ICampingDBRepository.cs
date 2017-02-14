using CampingDB.Models;

namespace CampingDB.Repositories
{
    public interface ICampingDBRepository
    {
        IGenericRepository<CampingPlace> GetCampingPlaceRepository();
        IGenericRepository<SiteCategory> GetSiteCategoryRepository();
    }
}
