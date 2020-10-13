using StudentCertification_BusinessAccessLayer;
using StudentCertification_Entities;
using StudentCertificationProgram.CustomActionResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCertificationProgram.Controllers
{
    public class DecisionController : Controller
    {
        private readonly IStudentDecisionBusinessAccess studentDecisionBusinessAccess;
        private readonly IStudentInfoBusinessAccess studentInfoBusinessAccess;
        public DecisionController(IStudentDecisionBusinessAccess studentDecisionBusinessAccess, IStudentInfoBusinessAccess studentInfoBusinessAccess)
        {
            this.studentDecisionBusinessAccess = studentDecisionBusinessAccess;
            this.studentInfoBusinessAccess = studentInfoBusinessAccess;
        }

        public DecisionController()
        {
        }

        // GET: Decision
        [CustomFilters.CustomExceptionFilter]
        public ActionResult DecisionInfo()
        {
            try { 
            StudentDecisionQualification studentDecisionQualification = new StudentDecisionQualification();
            studentDecisionQualification.studentId = (int)Session["studentId"];
            if ((int)Session["marks"] > 80)
                studentDecisionQualification.isQualified = true;
            else
                studentDecisionQualification.isQualified = false;
            studentDecisionBusinessAccess.InsertDecisionInfoIntoDatabase(studentDecisionQualification);
            if (studentDecisionQualification.isQualified)
                return RedirectToAction("QualifiedSuccess", "Decision");
            else
                return View();
            }
            catch (Exception exception)
            {
                return View("Error");
            }
        }
        public ActionResult QualifiedSuccess()
        {
            return View();
        }
        public XmlResult QualifiedStudentsinXML()
        {
         
            List<StudentDecisionQualification> studentsQualified = studentDecisionBusinessAccess.DisplaySuccessfulStudents();
           
            List<StudentInfo> studentQualifiedInfo = new List<StudentInfo>();
            foreach (StudentDecisionQualification student in studentsQualified)
            {
                studentQualifiedInfo.Add(studentInfoBusinessAccess.DisplayStudentInfoByIdFromDatabase(student.studentId));
            }
            return new XmlResult(studentQualifiedInfo);
            
        }
        public CSVResult<StudentInfo> QualifiedStudentinCSV()
        {
            
            List<StudentDecisionQualification> studentsQualified = studentDecisionBusinessAccess.DisplaySuccessfulStudents();

            List<StudentInfo> studentQualifiedInfo = new List<StudentInfo>();
            foreach (StudentDecisionQualification student in studentsQualified)
            {
                studentQualifiedInfo.Add(studentInfoBusinessAccess.DisplayStudentInfoByIdFromDatabase(student.studentId));
            }
            return new CSVResult<StudentInfo>(studentQualifiedInfo,"QualifiedStudents.csv");
        }
    }
}