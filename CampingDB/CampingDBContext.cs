using CampingDB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CampingDB
{
    public class CampingDBContext : DbContext
    {
        public CampingDBContext()
            : base("CampingDB")
        {
        }

        public IDbSet<SiteCategory> SiteCategories { get; set; }
        public IDbSet<CampingPlace> CampingPlaces { get; set; }
        public DbSet<CampingUser> CampingUsers { get; set; }
        public DbSet<Sightseeing> Sightseeings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
