using Services.Models;
using System.Collections.Generic;

namespace MVP.Models
{
    public class AddCampingPlaceViewModel
    {
        public IEnumerable<ISiteCategory> SiteCategories { get; set; }
        public IEnumerable<ISightseeing> Sightseeings { get; set; }
    }
}
