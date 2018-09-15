using Scrum.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrum.Models.UserViewModel
{
    public class DetailsUserViewModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public Role Role { get; set; }
    }
}