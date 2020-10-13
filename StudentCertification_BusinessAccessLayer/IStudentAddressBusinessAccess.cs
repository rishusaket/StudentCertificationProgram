using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_BusinessAccessLayer
{
    public interface IStudentAddressBusinessAccess
    {
        void InsertStudentAddressInfoIntoDatabase(StudentAddressInfo student);
        void UpdateStudentAddressInfoIntoDatabase(StudentAddressInfo student);
        List<StudentAddressInfo> DisplayStudentAddressInfoFromDatabase();
        StudentAddressInfo DisplayStudentAddressInfoByIdFromDatabase(int id);
    }
}
