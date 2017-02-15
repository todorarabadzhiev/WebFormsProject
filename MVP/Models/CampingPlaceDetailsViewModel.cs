using Services.Models;
using System.Collections.Generic;

namespace MVP.Models
{
    public class CampingPlaceDetailsViewModel
    {
        public IEnumerable<ICampingPlace> CampingPlaceDetails { get; set; }
    }
}
