using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scrum.Infrastructure.Entities
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [Required]
        [StringLength(150)]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
       
    }
}