using Services.Models;
using System.Collections.Generic;

namespace MVP.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ICampingPlace> CampingPlaces { get; set; }
    }
}
