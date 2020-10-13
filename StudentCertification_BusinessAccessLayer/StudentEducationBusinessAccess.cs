using StudentCertification_DataAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_BusinessAccessLayer
{
    public class StudentEducationBusinessAccess : IStudentEducationBusinessAccess
    {
        private readonly IStudentEducationDataAccess studentEducationDataAccess;
        public StudentEducationBusinessAccess(IStudentEducationDataAccess studentEducationDataAccess)
        {
            this.studentEducationDataAccess = studentEducationDataAccess;
        }
        public void InsertStudentEducationInfoIntoDatabase(StudentEducationalInfo student)
        {
            try { 
            studentEducationDataAccess.InsertStudentEducationInfoIntoDatabase(student);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateStudentEducationInfoIntoDatabase(StudentEducationalInfo student)
        {
            try { 
            studentEducationDataAccess.UpdateStudentEducationInfoIntoDatabase(student);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
