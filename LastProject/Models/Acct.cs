using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class Acct : IValidatableObject
    {
        [Required]
        [Remote("AcctExist","Acct",HttpMethod = "POST",ErrorMessage = "Exist")]
        [Display(Name = "AcctId")]
        public int AcctId { get; set; }

        [Required]
        [Display(Name = "CustId")]
        public int CustId { get; set; }

        [Required]
        [Display(Name = "CustCat")]
        public char CustCat { get; set; }

        [Required]
        [Display(Name = "AcctCat")]
        public char AcctCat { get; set; }

        [Required]
        [Display(Name = "OpenDate")]
        public DateTime OpenDate { get; set; }

        public ICollection<AcctPos> AcctPos { get; set; }

        public Loan Loan { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
