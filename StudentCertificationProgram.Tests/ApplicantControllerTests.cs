using NUnit.Framework;
using StudentCertificationProgram.Controllers;
using System;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using Moq;
using System.Web;
using StudentCertification_BusinessAccessLayer;
using StudentCertification_Entities;

namespace StudentCertificationProgram.Tests
{
    [TestFixture]
    public class ApplicantControllerTests
    {
        StudentInfo student;
        StudentInfo student1 = default;
        [SetUp]
        public void SetUp()
        {
            student = new StudentInfo()
            {
                studentId = 1,
                studentName = "Rishu",
                emailId = "rishusaket@gmail.com",
                phoneNumber = "9945065745",
                UserAgent = "Mozilla",
                IpAddress = "11",
                contentType = "xml",
                highestCompletedStage = 10
            };

            
        }
        [Test]
        
        public void TestApplicantInfo_ReturningCorrectView_ForNullSessionId()
        {

            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentId"]).Returns(null);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;


            ApplicantController obj = new ApplicantController();
            
            obj.ControllerContext = ctx;
            var actResult = obj.ApplicantInfo() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("ApplicantInfo"));

        }
        [Test]
        public void TestApplicantInfo_ReturningCorrectView_ForNotNullSessionId()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentId"]).Returns(1);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentInfoBusinessAccess> businesslayer = new Mock<IStudentInfoBusinessAccess>();

            businesslayer.Setup(x => x.DisplayStudentInfoByIdFromDatabase(1)).Returns(student);

            ApplicantController obj = new ApplicantController(businesslayer.Object);
            obj.ControllerContext = ctx;
            var actResult = obj.ApplicantInfo() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("ApplicantInfo"));

        }

        [Test]
        public void TestApplicantInfo_ReturningCorrectView_ForException()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentId"]).Returns(0);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentInfoBusinessAccess> businesslayer = new Mock<IStudentInfoBusinessAccess>();
            var ex = new Exception();
            businesslayer.Setup(x => x.DisplayStudentInfoByIdFromDatabase(0)).Throws(ex);

            ApplicantController obj = new ApplicantController(businesslayer.Object);
            obj.ControllerContext = ctx;
            var actResult = obj.ApplicantInfo() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Error"));

        }

        [Test]
        public void TestPostApplicationInfo_WhenStudentIdIsNotNull()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentId"]).Returns(1);
            
            //Mock<HttpRequestBase> session2 = new Mock<HttpRequestBase>();
            //session2.Setup(s => s["HTTP_X_FORWARDED_FOR"]).Returns("11");

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);
            //httpContext.SetupGet(c => c.Request.ServerVariables).Returns(session2.Object);

            Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
            request.Setup(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection { { "HTTP_X_FORWARDED_FOR", "11" } });
            httpContext.SetupGet(x => x.Request).Returns(request.Object);



            httpContext.SetupGet(c => c.Request.UserAgent).Returns("Mozilla");
            httpContext.SetupGet(c => c.Request.ContentType).Returns("xml");
            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentInfoBusinessAccess> businesslayer = new Mock<IStudentInfoBusinessAccess>();

            businesslayer.Setup(x => x.UpdateStudentInfoIntoDatabase(student));

            //Creating application Controller onj
            ApplicantController applicantController = new ApplicantController(businesslayer.Object);
            applicantController.ControllerContext = ctx;

            RedirectToRouteResult result = applicantController.ApplicantInfo(student) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("AddressInfo"));
        }


        [Test]
        public void TestPostApplicationInfo_WhenStudentIdIsNull()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentId"]).Returns(null);

            //Mock<HttpRequestBase> session2 = new Mock<HttpRequestBase>();
            //session2.Setup(s => s["HTTP_X_FORWARDED_FOR"]).Returns("11");

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);
            //httpContext.SetupGet(c => c.Request.ServerVariables).Returns(session2.Object);

            Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
            request.Setup(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection { { "HTTP_X_FORWARDED_FOR", "11" } });
            httpContext.SetupGet(x => x.Request).Returns(request.Object);



            httpContext.SetupGet(c => c.Request.UserAgent).Returns("Mozilla");
            httpContext.SetupGet(c => c.Request.ContentType).Returns("xml");
            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentInfoBusinessAccess> businesslayer = new Mock<IStudentInfoBusinessAccess>();

            businesslayer.Setup(x => x.InsertStudentInfoIntoDatabase(student));

            //Creating application Controller onj
            ApplicantController applicantController = new ApplicantController(businesslayer.Object);
            applicantController.ControllerContext = ctx;

            RedirectToRouteResult result = applicantController.ApplicantInfo(student) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("AddressInfo"));
        }


        [Test]
        public void TestPostApplicationInfo_WhenStudentModelState_IsInvalid()
        {
            

            //Creating application Controller onj
            ApplicantController applicantController = new ApplicantController();

            applicantController.ModelState.AddModelError("xyz", "errorMessage");

            var result = applicantController.ApplicantInfo(student1) as ViewResult;
            

            Assert.That(result.ViewName, Is.EqualTo("ApplicantInfo"));
        }
    }
}
