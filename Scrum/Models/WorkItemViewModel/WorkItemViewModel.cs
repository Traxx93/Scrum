using Scrum.Infrastructure.Entities;
using Scrum.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrum.Models.WorkItemViewModel
{
    public class WorkItemViewModel
    {
        public int WorkItemID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int? UserID { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
 

    }
}