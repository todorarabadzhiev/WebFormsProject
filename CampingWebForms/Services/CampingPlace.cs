using System;
using System.Collections.Generic;

namespace CampingWebForms.Services
{
    public class CampingPlace : ICampingPlace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GoogleMapsUrl { get; set; }
        public bool HasWater { get; set; }
        public DateTime AddedOn { get; set; }
        public IEnumerable<Guid> SightseeingIds { get; set; }
        public IEnumerable<Guid> SiteCategoriesIds { get; set; }
        public IEnumerable<string> SiteCategoriesNames { get; set; }
        public IEnumerable<string> SightseeingNames { get; set; }
        public IEnumerable<string> SightseeingTypes { get; set; }
    }
}