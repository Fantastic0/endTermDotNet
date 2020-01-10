using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Models
{
    public class Op 
    {
        [Required]
        [Display(Name = "OpId")]
        public int OpId { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Inn")]
        public string Inn { get; set; }        

        [Required]
        [Display(Name = "OpDate")]
        public DateTime OpDate { get; set; }

        //public ICollection<OpEntry> OpEntries { get; set; }

        
    }
}
