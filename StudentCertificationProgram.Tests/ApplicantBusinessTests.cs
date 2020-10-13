using Moq;
using NUnit.Framework;
using StudentCertification_BusinessAccessLayer;
using StudentCertification_DataAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertificationProgram.Tests
{
    [TestFixture]
    public class ApplicantBusinessTests
    {
        public StudentInfo student;
        [SetUp]
        public void SetUp()
        {
            this.student = new StudentInfo()
            {
                studentName = "rishu",
                emailId = "xyz@gmail.com",
                phoneNumber = "9945065745",
                UserAgent = "Mozilla",
                IpAddress = "112.11.10.01",
                contentType = "text/xml"
            };
        }

        [Test]
        public void Test_InsertStudentInfoIntoDatabase()
        {
            Mock<IStudentInfoDataAccess> mock = new Mock<IStudentInfoDataAccess>();
            mock.Setup(x => x.InsertStudentInfoIntoDatabase(student)).Returns(1);
            try
            {
                StudentInfoBusinessAccess studentInfoBusiness = new StudentInfoBusinessAccess(mock.Object);
                studentInfoBusiness.InsertStudentInfoIntoDatabase(student);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
            
        }

    }
}
