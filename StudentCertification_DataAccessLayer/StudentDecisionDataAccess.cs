using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_DataAccessLayer
{
    public class StudentDecisionDataAccess : IStudentDecisionDataAccess
    {
        private readonly SqlConnection connection;
        public StudentDecisionDataAccess()
        {
            ConnectionStringValue connectionString = new ConnectionStringValue();
            this.connection = new SqlConnection(connectionString.connectionString);
        }

        public List<StudentDecisionQualification> DisplaySuccessfulStudents()
        {
            try
            { 
           using(connection)
            {
                List<StudentDecisionQualification> studentsQualificationData = new List<StudentDecisionQualification>();
                SqlCommand sqlCommand = new SqlCommand("DisplaySuccessfulStudentsStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    studentsQualificationData.Add(new StudentDecisionQualification
                    {
                        qualificationId = Convert.ToInt32(row["qualificationId"]),
                        isQualified = Convert.ToBoolean(row["isQualified"]),
                        studentId = Convert.ToInt32(row["studentId"])
                    });
                }
                return studentsQualificationData;

            }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void InsertDecisionInfoIntoDatabase(StudentDecisionQualification studentDecision)
        {
            try
            { 
            using(connection)
            {
                SqlCommand sqlCommand = new SqlCommand("InsertDecisionInfoIntoDatabaseStoredProcedure", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@isQualified", studentDecision.isQualified);
                sqlCommand.Parameters.AddWithValue("@studentId", studentDecision.studentId);
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
