using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_Entities
{
    public class StudentDecisionQualification
    {
        public int qualificationId { get; set; }
        public bool isQualified { get; set; }
        public int studentId { get; set; }
    }
}
