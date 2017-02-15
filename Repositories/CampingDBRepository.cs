using CampingDB.Models;
using System.Data.Entity;

namespace Repositories
{
    public class CampingDBRepository : ICampingDBRepository
    {
        private readonly DbContext dbContext;

        public CampingDBRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IGenericRepository<CampingPlace> GetCampingPlaceRepository()
        {
            return new CampingDBGenericRepository<CampingPlace>(this.dbContext);
        }

        public IGenericRepository<SiteCategory> GetSiteCategoryRepository()
        {
            return new CampingDBGenericRepository<SiteCategory>(this.dbContext);
        }

        public IGenericRepository<Sightseeing> GetSightseeingRepository()
        {
            return new CampingDBGenericRepository<Sightseeing>(this.dbContext);
        }
    }
}
