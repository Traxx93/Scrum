using Scrum.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Models.WorkItemViewModel
{
    public class EditWorkItemViewModel
    {
        public int WorkItemID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int? UserID { get; set; }
        public IEnumerable<SelectListItem> ListOfUserIDs { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}