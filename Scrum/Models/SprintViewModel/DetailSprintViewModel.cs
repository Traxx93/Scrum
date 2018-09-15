using Scrum.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrum.Models.SprintViewModel
{
    public class DetailSprintViewModel
    {
        public int SprintID { get; set; }
        public string SprintName { get; set; }
        public string MainTask { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ProjectID { get; set; }

    }
}