using CustomExceptionLogger;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_DataAccessLayer
{
    public interface IStudentCertificationDataAccess
    {
        void InsertExceptionIntoDatabase(ExceptionLogger logger);
    }
}
