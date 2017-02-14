using CampingWebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampingWebForms.Models
{
    public class AddCampingPlaceViewModel
    {
        public IEnumerable<ISiteCategory> SiteCategories { get; set; }
        public IEnumerable<ISightseeing> Sightseeings { get; set; }
    }
}