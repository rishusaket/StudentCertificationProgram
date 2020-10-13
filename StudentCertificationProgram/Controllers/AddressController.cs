using StudentCertification_BusinessAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCertificationProgram.Controllers
{
    public class AddressController : Controller
    {
        private readonly IStudentAddressBusinessAccess studentAddressBusinessAccess;

        public AddressController()
        {
        }

        public AddressController(IStudentAddressBusinessAccess studentAddressBusinessAccess)
        {
            this.studentAddressBusinessAccess = studentAddressBusinessAccess;
            
        }
        // GET: Address
        [CustomFilters.StudentWorkflowFilter((int)WorkflowValues.WorkFlow.ApplicantStage, (int)WorkflowValues.WorkFlow.AddressStage)]
        [CustomFilters.CustomExceptionFilter]
        public ActionResult AddressInfo()
        {
            try {
            StudentAddressInfo student = new StudentAddressInfo();
            if(Session["studentAddressId"] != null)
            {
                student = studentAddressBusinessAccess.DisplayStudentAddressInfoByIdFromDatabase((int)Session["studentAddressId"]);
                return View("AddressInfo",student);
            }

            return View("AddressInfo",student);
            }
            catch (Exception exception)
            {
                return View("Error");
            }
        }
        [HttpPost]
        [CustomFilters.StudentWorkflowFilter((int)WorkflowValues.WorkFlow.ApplicantStage, (int)WorkflowValues.WorkFlow.AddressStage)]
        [CustomFilters.CustomExceptionFilter]
        public ActionResult AddressInfo(StudentAddressInfo studentAddressInfo)
        {
            try { 
            if (ModelState.IsValid)
            {
                if(Session["studentAddressId"] != null)
                {
                    studentAddressBusinessAccess.UpdateStudentAddressInfoIntoDatabase(studentAddressInfo);
                }
                else
                {
                    studentAddressBusinessAccess.InsertStudentAddressInfoIntoDatabase(studentAddressInfo);
                }
                return RedirectToAction("QualificationInfo", "Qualification");
            }
            return View("AddressInfo");
        }
            catch (Exception exception)
            {
                return View("Error");
    }
}
    }
}