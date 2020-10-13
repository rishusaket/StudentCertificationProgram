using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_DataAccessLayer
{
    public interface IStudentDecisionDataAccess
    {
        void InsertDecisionInfoIntoDatabase(StudentDecisionQualification studentDecision);
        List<StudentDecisionQualification> DisplaySuccessfulStudents();
    }
}
