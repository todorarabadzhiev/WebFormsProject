namespace CampingDB.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CampingDB.CampingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CampingDB.CampingDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Sightseeings.AddOrUpdate(
              s => s.Name,
              new Sightseeing { Name = "Пещери" },
              new Sightseeing { Name = "Водопади" },
              new Sightseeing { Name = "Исторически събития" },
              new Sightseeing { Name = "Археологически разкопки" },
              new Sightseeing { Name = "Развлечения" }
            );
            context.SiteCategories.AddOrUpdate(
              s => s.Name,
              new SiteCategory { Name = "Море" },
              new SiteCategory { Name = "Планина" },
              new SiteCategory { Name = "Река" },
              new SiteCategory { Name = "Язовир" },
              new SiteCategory { Name = "Остров" }
            );
        }
    }
}
