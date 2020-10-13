using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_Entities
{
    public class StudentEducationalInfo
    {
        [Key]
        public int studentEductionalId { get; set; }
        [Required(ErrorMessage = "Please Enter your percentage")]
        
        public string secondarySchoolName { get; set; }
        [Required(ErrorMessage = "Please Enter your percentage")]
        
        public string seniorSecondarySchoolName { get; set; }
        
        [Required(ErrorMessage ="Please enter the College Name")]
        public string collegeName { get; set; }
        [Required(ErrorMessage = "Please Enter your percentage")]
        [Range(0.0, 100.0, ErrorMessage = "Please enter percentage from 1 to 100")]
        public float collegePercentage { get; set; }

        public int studentId { get; set; }
    }
}
