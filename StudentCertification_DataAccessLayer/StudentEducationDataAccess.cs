using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace StudentCertification_DataAccessLayer
{
    public class StudentEducationDataAccess : Page,IStudentEducationDataAccess
    {
        private readonly SqlConnection connection;
        public StudentEducationDataAccess()
        {
            ConnectionStringValue connectionString = new ConnectionStringValue();
            this.connection = new SqlConnection(connectionString.connectionString);
        }

        public void InsertStudentEducationInfoIntoDatabase(StudentEducationalInfo student)
        {
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertStudentEducationInfoStoredProcedure", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@secondarySchoolName", student.secondarySchoolName);
                    sqlCommand.Parameters.AddWithValue("@seniorSecondarySchoolName", student.seniorSecondarySchoolName);
                    sqlCommand.Parameters.AddWithValue("@collegeName", student.collegeName);
                    sqlCommand.Parameters.AddWithValue("@collegePercentage", student.collegePercentage);
                    sqlCommand.Parameters.AddWithValue("@studentId", Session["studentId"]);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateStudentEducationInfoIntoDatabase(StudentEducationalInfo student)
        {
            try
            { 
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateStudentEducationInfoStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentEductionalId", student.studentEductionalId);
                sqlCommand.Parameters.AddWithValue("@secondarySchoolName", student.secondarySchoolName);
                sqlCommand.Parameters.AddWithValue("@seniorSecondarySchoolName", student.seniorSecondarySchoolName);
                sqlCommand.Parameters.AddWithValue("@collegeName", student.collegeName);
                sqlCommand.Parameters.AddWithValue("@collegePercentage", student.collegePercentage);
                sqlCommand.Parameters.AddWithValue("@studentId", Session["studentId"]);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
