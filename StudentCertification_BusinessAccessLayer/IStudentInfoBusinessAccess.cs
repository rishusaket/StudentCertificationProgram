using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_BusinessAccessLayer
{
    public interface IStudentInfoBusinessAccess
    {
        List<StudentInfo> DisplayStudentInfoFromDatabase();
        void InsertStudentInfoIntoDatabase(StudentInfo student);
        void UpdateStudentInfoIntoDatabase(StudentInfo student);
        int GetCurrentStageFromStudentInfo(int? studentId);
        StudentInfo DisplayStudentInfoByIdFromDatabase(int id);
        void UpdateStudentInfoCompletedStage(int currenStageValue, int studentID);
    }
}
