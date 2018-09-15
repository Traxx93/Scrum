using Scrum.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scrum.Models.ProjectViewModel
{
    public class AddProjectViewModel
    {
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
    }
}