using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_BusinessAccessLayer
{
    public interface IStudentDecisionBusinessAccess
    {
        void InsertDecisionInfoIntoDatabase(StudentDecisionQualification studentDecision);
        List<StudentDecisionQualification> DisplaySuccessfulStudents();
    }
}
