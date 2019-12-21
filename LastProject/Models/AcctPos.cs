using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class AcctPos : IValidatableObject
    {
        [Key]
        [Required]
        [Display(Name = "AcctPosId")]
        public int AcctPostId { get; set; }

        [Required]
        [Display(Name = "Acct")]
        public Acct Acct { get; set; }

        public int AcctId { get; set; }

        [Required]
        [Range(0,999999999999)]
        [Display(Name = "Balance")]
        public double Balance { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
