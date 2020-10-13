using StudentCertification_DataAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_BusinessAccessLayer
{
    public class StudentDecisionBusinessAccess : IStudentDecisionBusinessAccess
    {
        private readonly IStudentDecisionDataAccess studentDecisionDataAccess;
        public StudentDecisionBusinessAccess(IStudentDecisionDataAccess studentDecisionDataAccess)
        {
            this.studentDecisionDataAccess = studentDecisionDataAccess;
        }
        public List<StudentDecisionQualification> DisplaySuccessfulStudents()
        {
            try { 
            List<StudentDecisionQualification> successfulStudents = new List<StudentDecisionQualification>();

            successfulStudents = studentDecisionDataAccess.DisplaySuccessfulStudents();

            return successfulStudents.Where(x => x.isQualified == true).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void InsertDecisionInfoIntoDatabase(StudentDecisionQualification studentDecision)
        {
            try
            { 
            studentDecisionDataAccess.InsertDecisionInfoIntoDatabase(studentDecision);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
