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
    public class StudentAddressDataAccess : Page, IStudentAddressDataAccess
    {
        private readonly SqlConnection connection;
        public StudentAddressDataAccess()
        {
            ConnectionStringValue connectionString = new ConnectionStringValue();
            this.connection = new SqlConnection(connectionString.connectionString);
        }

        public List<StudentAddressInfo> DisplayStudentAddressInfoFromDatabase()
        {
            try
            { 
            using (connection)
            {
                List<StudentAddressInfo> studentAddresses = new List<StudentAddressInfo>();
                SqlCommand sqlCommand = new SqlCommand("DisplayStudentAddressInfoStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    studentAddresses.Add(new StudentAddressInfo()
                    {
                        studentAddressId = Convert.ToInt32(row["studentAddressId"]),
                        studentAddress = Convert.ToString(row["studentAddress"]),
                        city = Convert.ToString(row["city"]),
                        state = Convert.ToString(row["state"]),
                        studentId = Convert.ToInt32(row["studentId"])
                    });
                }
                return studentAddresses;
            }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public StudentAddressInfo DisplayStudentAddressInfoByIdFromDatabase(int id)
        {
            try { 
            StudentAddressInfo studentAddress = DisplayStudentAddressInfoFromDatabase().FirstOrDefault(x => x.studentAddressId == id);
            return studentAddress;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void InsertStudentAddressInfoIntoDatabase(StudentAddressInfo student)
        {
            try
            { 
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand("InsertStudentAddressInfoStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentAddress", student.studentAddress);
                sqlCommand.Parameters.AddWithValue("@city", student.city);
                sqlCommand.Parameters.AddWithValue("@state", student.state);
                sqlCommand.Parameters.AddWithValue("@studentId", Session["studentId"]);
                SqlCommand command = new SqlCommand("SELECT MAX(studentAddressId) FROM dbo.StudentAddressInfo", connection);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                Session["studentAddressId"] = (Int32)command.ExecuteScalar();

            }
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
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateStudentAddressInfoStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@studentAddressId", student.studentAddressId);
                sqlCommand.Parameters.AddWithValue("@studentAddress", student.studentAddress);
                sqlCommand.Parameters.AddWithValue("@city", student.city);
                sqlCommand.Parameters.AddWithValue("@state", student.state);
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
