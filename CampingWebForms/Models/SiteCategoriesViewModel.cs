using CampingWebForms.Services;
using System.Collections.Generic;

namespace CampingWebForms.Models
{
    public class SiteCategoriesViewModel
    {
        public IEnumerable<ISiteCategory> SiteCategories { get; set; }
    }
}