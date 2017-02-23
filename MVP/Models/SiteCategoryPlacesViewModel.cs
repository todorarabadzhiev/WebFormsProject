using Services.Models;
using System.Collections.Generic;

namespace MVP.Models
{
    public class SiteCategoryPlacesViewModel
    {
        public IEnumerable<ICampingPlace> CampingPlaces { get; set; }
    }
}
