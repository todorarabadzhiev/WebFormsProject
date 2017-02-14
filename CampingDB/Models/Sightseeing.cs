using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingDB.Models
{
    public class Sightseeing
    {
        private ICollection<CampingPlace> campingPlaces;
        public Sightseeing()
        {
            this.campingPlaces = new HashSet<CampingPlace>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30), MinLength(2)]
        public string Name { get; set; }
        public virtual SightseeingType Type { get; set; }
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
