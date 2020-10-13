using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_DataAccessLayer
{
    public interface IStudentInfoDataAccess
    {
        List<StudentInfo> DisplayStudentInfoFromDatabase();
        StudentInfo DisplayStudentInfoByIdFromDatabase(int id);
        int InsertStudentInfoIntoDatabase(StudentInfo student);
        int UpdateStudentInfoIntoDatabase(StudentInfo student);
        int GetCurrentStageFromStudentInfo(int? studentId);
        void UpdateStudentInfoCompletedStage(int currenStageValue, int studentID);

    }
}
