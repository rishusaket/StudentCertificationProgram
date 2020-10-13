using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_DataAccessLayer
{
    /// <summary>
    /// Interface for accessing student data access class which contains the declarations of the methods
    /// </summary>
    public interface IStudentAddressDataAccess
    {
        /// <summary>
        /// To insert the student data into the database
        /// </summary>
        /// <param name="student"></param>
        void InsertStudentAddressInfoIntoDatabase(StudentAddressInfo student);
        /// <summary>
        /// To update the student data into the database
        /// </summary>
        /// <param name="student"></param>
        void UpdateStudentAddressInfoIntoDatabase(StudentAddressInfo student);
        /// <summary>
        /// To display the student info based on paramter passed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StudentAddressInfo DisplayStudentAddressInfoByIdFromDatabase(int id);
        /// <summary>
        /// To display a list of student from database
        /// </summary>
        /// <returns></returns>
        List<StudentAddressInfo> DisplayStudentAddressInfoFromDatabase();
    }
}
