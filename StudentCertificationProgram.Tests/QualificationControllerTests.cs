using Moq;
using NUnit.Framework;
using StudentCertification_BusinessAccessLayer;
using StudentCertification_Entities;
using StudentCertificationProgram.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentCertificationProgram.Tests
{
    [TestFixture]
    public class QualificationControllerTests
    {
        public StudentEducationalInfo student;
        public StudentEducationalInfo student2 = default;
        [SetUp]
        public void SetUp()
        {
            student = new StudentEducationalInfo()
            {
                secondarySchoolName = "Don Bosco",
                seniorSecondarySchoolName = "Shivam International",
                collegeName = "JSS",
                collegePercentage = 90
            };
        }

        [Test]
        public void TestQualificationController_ReturningCorrectView()
        {
            QualificationController qualificationController = new QualificationController();
            ViewResult result = qualificationController.QualificationInfo() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("QualificationInfo"));
        }

        [Test]
        public void TestPostQualificationController_RedirectingCorrectly()
        {
            Mock<IStudentEducationBusinessAccess> mock = new Mock<IStudentEducationBusinessAccess>();
            mock.Setup(x => x.InsertStudentEducationInfoIntoDatabase(student));
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["marks"]).Returns(90);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            QualificationController controller = new QualificationController(mock.Object);
            controller.ControllerContext = ctx;

            RedirectToRouteResult result = controller.QualificationInfo(student) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("DecisionInfo"));
        }

        [Test]
        public void TestPostQualificationController_WhenModelStateIsInvalid()
        {
            QualificationController controller = new QualificationController();

            controller.ModelState.AddModelError("xyz", "An error has occured");

            ViewResult result = controller.QualificationInfo(student2) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("QualificationInfo"));
        }

        [Test]
        public void TestPostQualificationController_WhenExceptionOccurs()
        {
            Mock<IStudentEducationBusinessAccess> mock = new Mock<IStudentEducationBusinessAccess>();
            Exception exception = new Exception();
            mock.Setup(x => x.InsertStudentEducationInfoIntoDatabase(student)).Throws(exception);
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["marks"]).Returns(90);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            QualificationController controller = new QualificationController(mock.Object);
            controller.ControllerContext = ctx;

            ViewResult result = controller.QualificationInfo(student) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }

    }
}
