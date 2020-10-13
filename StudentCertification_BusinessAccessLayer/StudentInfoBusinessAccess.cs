using StudentCertification_DataAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_BusinessAccessLayer
{
    /// <summary>
/// Inherit from the interface to implement 
/// </summary>
    public class StudentInfoBusinessAccess : IStudentInfoBusinessAccess
    {
        private readonly IStudentInfoDataAccess studentInfoDataAccess;
        /// <summary>
        /// contructor to initialise the DAL layer class
        /// </summary>
        public StudentInfoBusinessAccess(IStudentInfoDataAccess studentInfoDataAccess)
        {
            this.studentInfoDataAccess = studentInfoDataAccess;
        }

        public void InsertStudentInfoIntoDatabase(StudentInfo student)
        {
            try
            { 
            int value = studentInfoDataAccess.InsertStudentInfoIntoDatabase(student);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateStudentInfoIntoDatabase(StudentInfo student)
        {
            try {
                int value =  studentInfoDataAccess.UpdateStudentInfoIntoDatabase(student);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public int GetCurrentStageFromStudentInfo(int? studentId)
        {
            try
            { 
            return studentInfoDataAccess.GetCurrentStageFromStudentInfo(studentId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<StudentInfo> DisplayStudentInfoFromDatabase()
        {
            try
            { 
            return studentInfoDataAccess.DisplayStudentInfoFromDatabase();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public StudentInfo DisplayStudentInfoByIdFromDatabase(int id)
        {
            try
            { 
            return studentInfoDataAccess.DisplayStudentInfoByIdFromDatabase(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void UpdateStudentInfoCompletedStage(int currenStageValue, int studentID)
        {
            try { 
            studentInfoDataAccess.UpdateStudentInfoCompletedStage(currenStageValue, studentID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}