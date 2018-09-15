using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scrum.Infrastructure.Enums
{
    public enum Status
    {
        [Display(Name = "To Do")]
        TO_DO = 0,
        [Display(Name = "In Progress")]
        IN_PROGRESS = 1,
        [Display(Name = "Done")]
        DONE = 2
    }
}