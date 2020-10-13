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
    public class AddressControllerTests
    {
        public StudentAddressInfo student;
        public StudentAddressInfo student2 = default;
        [SetUp]
        public void SetUp()
        {
            student = new StudentAddressInfo()
            {
                
                studentAddress = "Boring Road",
                city = "Patna",
                state = "Bihar",
                
            };
        }

        [Test]
        public void TestAddressInfo_ReturningCorrectViewForNullSessionId()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentAddressId"]).Returns(null);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            AddressController addressController = new AddressController();
            addressController.ControllerContext = ctx;

            ViewResult result = addressController.AddressInfo() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("AddressInfo"));
        }

        [Test]
        public void TestAddressInfo_ReturningCorrectViewForNotNullSessionId()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentAddressId"]).Returns(2);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentAddressBusinessAccess> mock = new Mock<IStudentAddressBusinessAccess>();
            mock.Setup(x => x.DisplayStudentAddressInfoByIdFromDatabase(2)).Returns(student);

            AddressController addressController = new AddressController(mock.Object);
            addressController.ControllerContext = ctx;

            ViewResult result = addressController.AddressInfo() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("AddressInfo"));
        }

        [Test]
        public void TestAddressInfo_ReturningExceptionViewForNotNullSessionId()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentAddressId"]).Returns(2);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentAddressBusinessAccess> mock = new Mock<IStudentAddressBusinessAccess>();
            Exception exception = new Exception();
            mock.Setup(x => x.DisplayStudentAddressInfoByIdFromDatabase(2)).Throws(exception);

            AddressController addressController = new AddressController(mock.Object);
            addressController.ControllerContext = ctx;

            ViewResult result = addressController.AddressInfo() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }

        [Test]
        public void TestPostAddressInfo_ReturningCorrectView_ForNullStudentId()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentAddressId"]).Returns(null);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentAddressBusinessAccess> mock = new Mock<IStudentAddressBusinessAccess>();
            mock.Setup(x => x.InsertStudentAddressInfoIntoDatabase(student));

            AddressController addressController = new AddressController(mock.Object);
            addressController.ControllerContext = ctx;

            RedirectToRouteResult result = addressController.AddressInfo(student) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("QualificationInfo"));
        }

        [Test]
        public void TestPostAddressInfo_ReturningCorrectView_ForNotNullStudentId()
        {
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["studentAddressId"]).Returns(1);

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            Mock<IStudentAddressBusinessAccess> mock = new Mock<IStudentAddressBusinessAccess>();
            mock.Setup(x => x.UpdateStudentAddressInfoIntoDatabase(student));

            AddressController addressController = new AddressController(mock.Object);
            addressController.ControllerContext = ctx;

            RedirectToRouteResult result = addressController.AddressInfo(student) as RedirectToRouteResult;

            Assert.That(result.RouteValues["action"], Is.EqualTo("QualificationInfo"));
        }

        [Test]
        public void TestPostAddressInfo_WhenModelStateIsInvalid()
        {
            AddressController addressController = new AddressController();

            addressController.ModelState.AddModelError("xyz", "Error has occured");

            ViewResult result = addressController.AddressInfo(student2) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("AddressInfo"));
        }
    }
}
