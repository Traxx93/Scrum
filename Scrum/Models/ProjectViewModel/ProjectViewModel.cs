using Scrum.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrum.Models.ProjectViewModel
{
    public class ProjectViewModel
    {

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public ICollection<Sprint>Sprints { get; set; }
    }
}