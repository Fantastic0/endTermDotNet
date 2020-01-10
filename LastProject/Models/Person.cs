using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class Person
    {
        [Required]
        [Display(Name = "PersonId")]
        public int PersonId { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Inn")]
        public string Inn { get; set; }

        [Required]
        [Display(Name = "NameLast")]
        public string NameLast { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "OpenDate")]
        public DateTime OpenDate { get; set; }

        public Person() { }

        
    }
}

