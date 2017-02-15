using CampingWebForms.Services;
using System.Collections.Generic;

namespace CampingWebForms.Models
{
    public class AddCampingPlaceViewModel
    {
        public IEnumerable<ISiteCategory> SiteCategories { get; set; }
        public IEnumerable<ISightseeing> Sightseeings { get; set; }
    }
}