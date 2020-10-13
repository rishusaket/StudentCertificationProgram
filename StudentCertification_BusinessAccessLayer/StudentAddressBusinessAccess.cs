using StudentCertification_DataAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentCertification_BusinessAccessLayer
{
    public class StudentAddressBusinessAccess : IStudentAddressBusinessAccess
    {
        private readonly IStudentAddressDataAccess studentAddressDataAccess;
        public StudentAddressBusinessAccess(IStudentAddressDataAccess studentAddressDataAccess)
        {
            this.studentAddressDataAccess = studentAddressDataAccess;
        }
        public void InsertStudentAddressInfoIntoDatabase(StudentAddressInfo student)
        {
            try
            { 
            studentAddressDataAccess.InsertStudentAddressInfoIntoDatabase(student);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateStudentAddressInfoIntoDatabase(StudentAddressInfo student)
        {
            try
            { 
            studentAddressDataAccess.UpdateStudentAddressInfoIntoDatabase(student);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<StudentAddressInfo> DisplayStudentAddressInfoFromDatabase()
        {
            try
            { 
            return studentAddressDataAccess.DisplayStudentAddressInfoFromDatabase();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public StudentAddressInfo DisplayStudentAddressInfoByIdFromDatabase(int id)
        {
            try
            { 
            return studentAddressDataAccess.DisplayStudentAddressInfoByIdFromDatabase(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
