using System;

namespace MVP.Models.EventModels
{
    public class NameEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public NameEventArgs(string name)
        {
            this.Name = name;
        }
    }
}
