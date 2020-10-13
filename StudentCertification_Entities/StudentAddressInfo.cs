using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_Entities
{
    public class StudentAddressInfo
    {
        [Key]
        public int studentAddressId{get;set;}
        [Required(ErrorMessage ="Please enter your Address")]
        [StringLength(100)]
        public string studentAddress { get; set; }
        [Required(ErrorMessage = "Please enter your City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please enter your State")]
        public string state { get; set; }            
        public int studentId { get; set; }
    }
}
