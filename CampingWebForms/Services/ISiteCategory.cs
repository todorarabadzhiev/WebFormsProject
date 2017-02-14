using System;

namespace CampingWebForms.Services
{
    public interface ISiteCategory
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
