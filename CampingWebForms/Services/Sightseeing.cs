using System;

namespace CampingWebForms.Services
{
    public class Sightseeing : ISightseeing
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}