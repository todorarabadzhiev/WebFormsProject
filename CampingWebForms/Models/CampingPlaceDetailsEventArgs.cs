using System;

namespace CampingWebForms.Models
{
    public class CampingPlaceDetailsEventArgs : EventArgs
    {
        public Guid Id { get; private set; }
        public CampingPlaceDetailsEventArgs(Guid id)
        {
            this.Id = id;
        }
    }
}