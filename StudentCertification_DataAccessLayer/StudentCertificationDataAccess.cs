using CustomExceptionLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_DataAccessLayer
{
    public class StudentCertificationDataAccess : IStudentCertificationDataAccess
    {
        private readonly SqlConnection connection;
        public StudentCertificationDataAccess()
        {
            ConnectionStringValue connectionString = new ConnectionStringValue();
            this.connection = new SqlConnection(connectionString.connectionString);
        }
        public void InsertExceptionIntoDatabase(ExceptionLogger logger)
        {
            try
            { 
            using (connection)
            {
                SqlCommand command = new SqlCommand("ExceptionLoggerStoredProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExceptionMessage", logger.ExceptionMessage);
                command.Parameters.AddWithValue("@ControllerName", logger.ControllerName);
                command.Parameters.AddWithValue("@ActionName", logger.ActionName);
                command.Parameters.AddWithValue("@ExceptionStackTrack", logger.ExceptionStackTrack);
                command.Parameters.AddWithValue("@ExceptionLogTime", logger.ExceptionLogTime);
                connection.Open();
                command.ExecuteNonQuery();
            }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
