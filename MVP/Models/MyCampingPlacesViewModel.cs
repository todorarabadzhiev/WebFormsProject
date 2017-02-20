using Services.Models;
using System.Collections.Generic;

namespace MVP.Models
{
    public class MyCampingPlacesViewModel
    {
        public IEnumerable<ICampingPlace> MyCampingPlaces { get; set; }
    }
}
