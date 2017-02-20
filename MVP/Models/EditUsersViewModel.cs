using Services.Models;
using System.Collections.Generic;

namespace MVP.Models
{
    public class EditUsersViewModel
    {
        public IEnumerable<ICampingUser> CampingUsers { get; set; }
    }
}
