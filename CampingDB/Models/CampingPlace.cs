using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingDB.Models
{
    public class CampingPlace
    {
        private ICollection<SiteCategory> siteCategories;
        private ICollection<Sightseeing> sightseeings;

        public CampingPlace()
        {
            this.siteCategories = new HashSet<SiteCategory>();
            this.sightseeings = new HashSet<Sightseeing>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30), MinLength(2)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClosestTown { get; set; }
        public string GoogleMapsUrl { get; set; }
        public bool WaterOnSite { get; set; }
        public DateTime AddedOn { get; set; }
        public CampingUser AddedBy { get; set; }

        public virtual ICollection<SiteCategory> SiteCategories
        {
            get
            {
                return this.siteCategories;
            }
            set
            {
                this.siteCategories = value;
            }
        }

        public virtual ICollection<Sightseeing> Sightseeings
        {
            get
            {
                return this.sightseeings;
            }
            set
            {
                this.sightseeings = value;
            }
        }
    }
}
