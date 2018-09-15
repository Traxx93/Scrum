using Scrum.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Models.WorkItemViewModel
{
    public class AddWorkItemViewModel
    {
        public int WorkItemID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int? UserID { get; set; }

        public int SprintID { get; set; }
        public IEnumerable<SelectListItem> ListOfUserIDs { get; set; }         


        

    }
}