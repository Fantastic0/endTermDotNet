using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

    }
}
