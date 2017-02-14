using System;
using System.Collections.Generic;

namespace CampingWebForms.Services
{
    public interface ICampingPlace
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string GoogleMapsUrl { get; set; }
        bool HasWater { get; set; }
        DateTime AddedOn { get; set; }
        IEnumerable<Guid> SightseeingIds { get; set; }
        IEnumerable<Guid> SiteCategoriesIds { get; set; }
        IEnumerable<string> SiteCategoriesNames { get; set; }
        IEnumerable<string> SightseeingNames { get; set; }
        IEnumerable<string> SightseeingTypes { get; set; }
    }
}
