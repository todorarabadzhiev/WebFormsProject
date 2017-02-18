using System;

namespace MVP.Models.EventModels
{
    public class CreateUserClickEventArgs : EventArgs
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public CreateUserClickEventArgs(string appUserId, 
            string firstName, string lastName, string userName)
        {
            this.ApplicationUserId = appUserId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
        }
    }
}
