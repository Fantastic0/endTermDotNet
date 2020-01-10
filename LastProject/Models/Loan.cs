using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class Loan 
    {
        [Required]
        [Display(Name = "LoanId")]
        public int LoanId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Contract")]
        public string Contract { get; set; }

        
        /*[Display(Name = "Acct")]
        public Acct Acct { get; set; }*/

        public int AcctId { get; set; }

        [Required]
        [Display(Name = "CustId")]
        public int CustId { get; set; }

        [Required]
        [Display(Name = "CustCat")]
        public char CustCat { get; set; }

        
    }
}
