using Services.Models;
using System.Collections.Generic;

namespace MVP.Models
{
    public class SiteCategoriesViewModel
    {
        public IEnumerable<ISiteCategory> SiteCategories { get; set; }
    }
}
