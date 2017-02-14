using CampingWebForms.Services;
using System.Collections.Generic;

namespace CampingWebForms.Models
{
    public class CampingPlaceDetailsViewModel
    {
        public IEnumerable<ICampingPlace> CampingPlaceDetails { get; set; }
    }
}