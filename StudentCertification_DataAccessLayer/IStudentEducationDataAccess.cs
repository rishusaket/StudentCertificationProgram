using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_DataAccessLayer
{
    public interface IStudentEducationDataAccess
    {
        void InsertStudentEducationInfoIntoDatabase(StudentEducationalInfo student);
        void UpdateStudentEducationInfoIntoDatabase(StudentEducationalInfo student);
    }
}
