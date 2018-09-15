using Scrum.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Infrastructure.Entities
{
    public class WorkItem
    {
        [Key]
        public int WorkItemID { get; set; }

        [StringLength(100)]
        [Required]
        public string Subject { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public Status Status { get; set; }
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}