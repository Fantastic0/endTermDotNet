using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class OpEntry 
    {
        [Required]
        [Display(Name = "OpEntryId")]
        public int OpEntryId { get; set; }

        
        /*[Display(Name = "Op")]
        public Op Op { get; set; }*/
        [Display(Name = "OpId")]
        public int OpId { get; set; }

        
        [Display(Name = "AcctCr")]
        public string AccrCr { get; set; }

        
        [Display(Name = "AcctDb")]
        public string AcctDb { get; set; }

        [Required]
        [Range(0,999999999999999999)]
        [Display(Name = "Balance")]
        public double Balance { get; set; }

        [Required]
        [Display(Name = "OpenDate")]
        public DateTime OpenDate { get; set; }

        
    }
}
