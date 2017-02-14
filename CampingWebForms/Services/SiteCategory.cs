using System;

namespace CampingWebForms.Services
{
    public class SiteCategory : ISiteCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}