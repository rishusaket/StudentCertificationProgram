using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace StudentCertification_DataAccessLayer
{
    /// <summary>
/// Student class to
/// </summary>
    public class StudentInfoDataAccess : Page,IStudentInfoDataAccess
    {
        private readonly SqlConnection connection;
        public StudentInfoDataAccess()
        {
            ConnectionStringValue connectionString = new ConnectionStringValue();
            this.connection = new SqlConnection(connectionString.connectionString);
        }
        public List<StudentInfo> DisplayStudentInfoFromDatabase()
        {
            try
            {
                using (connection)
                {
                    List<StudentInfo> students = new List<StudentInfo>();
                    SqlCommand sqlCommand = new SqlCommand("DisplayStudentInfoStoredProcedure", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    sqlDataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        students.Add(new StudentInfo()
                        {
                            studentId = Convert.ToInt32(row["studentId"]),
                            studentName = Convert.ToString(row["studentName"]),
                            emailId = Convert.ToString(row["emailId"]),
                            phoneNumber = Convert.ToString(row["phoneNumber"]),
                            UserAgent = Convert.ToString(row["UserAgent"]),
                            IpAddress = Convert.ToString(row["IpAddress"]),
                            contentType = Convert.ToString(row["contentType"]),
                            highestCompletedStage = Convert.ToInt32(row["highestCompletedStage"])

                        });
                    }
                    return students;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            
        }
        public int InsertStudentInfoIntoDatabase(StudentInfo student)
        {
            try 
            { 
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand("InsertStudentInfoStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentName", student.studentName);
                sqlCommand.Parameters.AddWithValue("@emailId", student.emailId);
                sqlCommand.Parameters.AddWithValue("@phoneNumber", student.phoneNumber);
                sqlCommand.Parameters.AddWithValue("@UserAgent", student.UserAgent);
                sqlCommand.Parameters.AddWithValue("@IpAddress", student.IpAddress);
                sqlCommand.Parameters.AddWithValue("@contentType", student.contentType);
                sqlCommand.Parameters.AddWithValue("@highestCompletedStage", student.highestCompletedStage);
                SqlCommand command = new SqlCommand("SELECT MAX(studentId) FROM dbo.StudentInfo", connection);
                
                connection.Open();
                int value = sqlCommand.ExecuteNonQuery();
                Session["studentId"] = (Int32)command.ExecuteScalar();
                    return value;
            }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int UpdateStudentInfoIntoDatabase(StudentInfo student)
        {
            try
            {

            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateStudentInfoStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentId", student.studentId);
                sqlCommand.Parameters.AddWithValue("@studentName", student.studentName);
                sqlCommand.Parameters.AddWithValue("@emailId", student.emailId);
                sqlCommand.Parameters.AddWithValue("@phoneNumber", student.phoneNumber);
                sqlCommand.Parameters.AddWithValue("@UserAgent", student.UserAgent);
                sqlCommand.Parameters.AddWithValue("@IpAddress", student.IpAddress);
                sqlCommand.Parameters.AddWithValue("@contentType", student.contentType);
                sqlCommand.Parameters.AddWithValue("@highestCompletedStage", student.highestCompletedStage);
                connection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                    return result;
            }
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
            using(connection)
            {
                SqlCommand sqlCommand = new SqlCommand("GetCurrentStageStoredProcedure", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentId", studentId);
                connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                int currentStage;
                while (dataReader.Read())
                {
                    currentStage = Convert.ToInt32(dataReader.GetInt32(7));
                    return currentStage;
                }
                return 0;

            }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public StudentInfo DisplayStudentInfoByIdFromDatabase(int id)
        {
            //using (connection)
            //{
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\M1049078\source\repos\StudentCertificationProgram\StudentCertification_DataAccessLayer\StudentCertificationDatabase.mdf;Integrated Security=True");
                StudentInfo student = new StudentInfo();

                SqlCommand sqlCommand = new SqlCommand("DisplayStudentInfoByIdFromDatabaseStoredProcedure", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentId", id);
                connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    student.studentId = Convert.ToInt32(dataReader.GetInt32(0));
                    student.studentName = Convert.ToString(dataReader.GetString(1));
                    student.emailId = Convert.ToString(dataReader.GetString(2));
                    student.phoneNumber = Convert.ToString(dataReader.GetString(3));
                    student.UserAgent = Convert.ToString(dataReader.GetString(4));
                    student.IpAddress = Convert.ToString(dataReader.GetString(5));
                    student.contentType = Convert.ToString(dataReader.GetString(6));
                }
                connection.Close();
                return student;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    //}


        public void UpdateStudentInfoCompletedStage(int currenStageValue, int studentID)
        {
            try 
            { 
            using(connection)
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateStudentInfoCompletedStageStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentId", studentID);
                sqlCommand.Parameters.AddWithValue("@highestCompletedStage", currenStageValue);
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
