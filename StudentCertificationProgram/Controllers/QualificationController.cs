using StudentCertification_BusinessAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCertificationProgram.Controllers
{
    public class QualificationController : Controller
    {
        private readonly IStudentEducationBusinessAccess studentEducationBusinessAccess;
        //private readonly IStudentInfoBusinessAccess studentInfoBusinessAccess;

        public QualificationController()
        {
        }

        public QualificationController(IStudentEducationBusinessAccess studentEducationBusinessAccess)
        {
            this.studentEducationBusinessAccess = studentEducationBusinessAccess;
            
        }
        // GET: Qualification
        [CustomFilters.StudentWorkflowFilter((int)WorkflowValues.WorkFlow.AddressStage, (int)WorkflowValues.WorkFlow.EducationStage)]
        [CustomFilters.CustomExceptionFilter]
        public ActionResult QualificationInfo()
        {
            return View("QualificationInfo");
        }

        [HttpPost]
        [CustomFilters.StudentWorkflowFilter((int)WorkflowValues.WorkFlow.AddressStage, (int)WorkflowValues.WorkFlow.EducationStage)]
        [CustomFilters.CustomExceptionFilter]
        public ActionResult QualificationInfo(StudentEducationalInfo studentEducation)
        {
            try
            { 
            if(ModelState.IsValid)
            {
                studentEducationBusinessAccess.InsertStudentEducationInfoIntoDatabase(studentEducation);
                Session["marks"] = (Int32)studentEducation.collegePercentage;
                return RedirectToAction("DecisionInfo", "Decision");
            }
            return View("QualificationInfo");
            }
            catch (Exception exception)
            {
                return View("Error");
            }
        }
    }
}