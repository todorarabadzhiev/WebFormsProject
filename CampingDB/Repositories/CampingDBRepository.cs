using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CampingDB.Models;

namespace CampingDB.Repositories
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
    }
}
