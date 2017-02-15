using System;

namespace MVP.Models.EventModels
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
