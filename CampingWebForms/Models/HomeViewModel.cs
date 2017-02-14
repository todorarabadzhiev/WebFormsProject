using CampingWebForms.Services;
using System.Collections.Generic;

namespace CampingWebForms.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ICampingPlace> CampingPlaces { get; set; }
    }
}