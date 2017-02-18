using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingDB.Models
{
    public class SiteCategory
    {
        private ICollection<CampingPlace> campingPlaces;
        public SiteCategory()
        {
            this.campingPlaces = new HashSet<CampingPlace>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30), MinLength(2)]
        public string Name { get; set; }
        public virtual ICollection<CampingPlace> CampingPlaces
        {
            get
            {
                return this.campingPlaces;
            }
            set
            {
                this.campingPlaces = value;
            }
        }
    }
}
