using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class OpEntry : IValidatableObject
    {
        [Required]
        [Display(Name = "OpEntryId")]
        public int OpEntryId { get; set; }

        [Required]
        [Display(Name = "Op")]
        public Op Op { get; set; }

        public int OpId { get; set; }

        [Required]
        [Display(Name = "AcctCr")]
        public Acct AccrCr { get; set; }

        [Required]
        [Display(Name = "AcctDb")]
        public Acct AcctDb { get; set; }

        [Required]
        [Range(0,999999999999999999)]
        [Display(Name = "Balance")]
        public double Balance { get; set; }

        [Required]
        [Display(Name = "OpenDate")]
        public DateTime OpenDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
