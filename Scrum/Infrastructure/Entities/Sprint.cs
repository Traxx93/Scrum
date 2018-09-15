using Scrum.Models.WorkItemViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Infrastructure.Entities
{
    public class Sprint
    {
        [Key]
        public int SprintID { get; set; }
        [Required]
        public string SprintName { get; set; }
        [Required]
        public string MainTask { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public int? ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }


    }
}