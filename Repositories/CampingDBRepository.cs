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
            return new EFGenericRepository<CampingPlace>(this.dbContext);
        }

        public IGenericRepository<SiteCategory> GetSiteCategoryRepository()
        {
            return new EFGenericRepository<SiteCategory>(this.dbContext);
        }

        public IGenericRepository<Sightseeing> GetSightseeingRepository()
        {
            return new EFGenericRepository<Sightseeing>(this.dbContext);
        }

        public IGenericRepository<ImageFile> GetImageFileRepository()
        {
            return new EFGenericRepository<ImageFile>(this.dbContext);
        }
    }
}
