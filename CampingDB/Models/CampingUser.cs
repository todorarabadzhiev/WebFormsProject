using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingDB.Models
{
    public class CampingUser
    {
        private ICollection<CampingPlace> myCampingPlaces;
        private ICollection<CampingPlace> favoriteCampingPlaces;

        public CampingUser()
        {
            this.myCampingPlaces = new HashSet<CampingPlace>();
            this.favoriteCampingPlaces = new HashSet<CampingPlace>();
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

        public virtual ICollection<CampingPlace> MyCampingPlaces
        {
            get
            {
                return this.myCampingPlaces;
            }
            set
            {
                this.myCampingPlaces = value;
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
