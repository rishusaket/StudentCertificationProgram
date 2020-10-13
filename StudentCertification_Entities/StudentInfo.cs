using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_Entities
{
    public class StudentInfo : IValidatableObject
    {
        [Key]
        public int studentId { get; set; }
        [Required(ErrorMessage ="Please Enter your name")]
        public string studentName { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage =("Please enter a valid email address"))]
        [Required(ErrorMessage = "Please Enter your emailId")]
        public string emailId { get; set; }
        [Required(ErrorMessage = "Please Enter your Phone Number")]
        [StringLength(10)]
        public string phoneNumber { get; set; }

        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public string contentType { get; set; }
        public int highestCompletedStage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.studentName.Equals("zz"))
                yield return new ValidationResult("You're not sleepin, Are you?", new[] { "studentName" });
        }
    }
}
