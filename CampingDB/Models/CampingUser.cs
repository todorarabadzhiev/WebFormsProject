using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingDB.Models
{
    public class CampingUser
    {
        private ICollection<CampingPlace> favoriteCampingPlaces;
        private ICollection<CampingPlace> addedCampingPlaces;

        public CampingUser()
        {
            this.favoriteCampingPlaces = new HashSet<CampingPlace>();
            this.addedCampingPlaces = new HashSet<CampingPlace>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }//take from Account

        [Required]
        [MaxLength(30), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30), MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30), MinLength(2)]
        public string UserName { get; set; }
        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<CampingPlace> AddedCampingPlaces
        {
            get
            {
                return this.addedCampingPlaces;
            }
            set
            {
                this.addedCampingPlaces = value;
            }
        }
        public virtual ICollection<CampingPlace> FavoriteCampingPlaces
        {
            get
            {
                return this.favoriteCampingPlaces;
            }
            set
            {
                this.favoriteCampingPlaces = value;
            }
        }
    }
}
