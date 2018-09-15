using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scrum.Infrastructure.Enums
{
    public enum Role
    {
        [Display(Name="Team member")]
        TEAM_MEMBER = 0,
        [Display(Name="Scrum master")]
        SCRUM_MASTER = 1,
        [Display(Name="Product owner")]
        PRODUCT_OWNER = 2
    }
}