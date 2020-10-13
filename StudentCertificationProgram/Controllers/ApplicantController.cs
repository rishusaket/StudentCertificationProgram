using StudentCertification_BusinessAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCertificationProgram.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IStudentInfoBusinessAccess studentInfoBusinessAccess;

        public ApplicantController()
        {
        }

        public ApplicantController(IStudentInfoBusinessAccess studentInfoBusinessAccess)
        {
            this.studentInfoBusinessAccess = studentInfoBusinessAccess;
        }

        [CustomFilters.CustomExceptionFilter]
        // GET: Applicant
        [CustomFilters.StudentWorkflowFilter((int)WorkflowValues.WorkFlow.Default, (int)WorkflowValues.WorkFlow.ApplicantStage)]
        public ActionResult ApplicantInfo()
        {
            try
            {
                StudentInfo student = new StudentInfo();
                if (Session["studentId"]==null)
                    return View("ApplicantInfo", student);

                student = studentInfoBusinessAccess.DisplayStudentInfoByIdFromDatabase((int)Session["studentId"]);
                return View("ApplicantInfo", student);
            }
            catch (Exception exception)
            {
                return View("Error");
            }
        }
        [CustomFilters.CustomExceptionFilter]
        [CustomFilters.StudentWorkflowFilter((int)WorkflowValues.WorkFlow.Default,(int)WorkflowValues.WorkFlow.ApplicantStage)]
        [HttpPost]
        public ActionResult ApplicantInfo([Bind(Include = "studentName, emailId, phoneNumber")]StudentInfo student)
        {
            try { 
            if (ModelState.IsValid)
            {
                var IPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(IPAddress))
                {
                    IPAddress = Request.ServerVariables["REMOTE_ADDR"];
                }
                var userAgent = Request.UserAgent;
                var contentType = Request.ContentType;
                student.IpAddress = IPAddress;
                student.UserAgent = userAgent;
                student.contentType = contentType;
                student.highestCompletedStage = 10;
                if (Session["studentId"] != null)
                {
                    studentInfoBusinessAccess.UpdateStudentInfoIntoDatabase(student);
                }
                else
                {
                    studentInfoBusinessAccess.InsertStudentInfoIntoDatabase(student);
                }
                return RedirectToAction("AddressInfo", "Address");
            }
            return View("ApplicantInfo");
            }
            catch (Exception exception)
            {
                return View("Error");
            }
        }

        public ActionResult ListOfModel(IEnumerable<int> val)
        {
            return View();
        }
    }
}