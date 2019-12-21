using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class Cust : IValidatableObject
    {
        [Required]
        [Display(Name = "CustId")]
        public int CustId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "ShortName")]
        public string ShortName { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Bin")]
        public string Bin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
