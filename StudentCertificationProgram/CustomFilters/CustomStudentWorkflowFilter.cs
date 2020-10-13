using StudentCertification_BusinessAccessLayer;
using StudentCertification_DataAccessLayer;
using StudentCertification_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.UI;

namespace StudentCertificationProgram.CustomFilters
{
    public class StudentWorkflowFilter : ActionFilterAttribute
    {

        private readonly int minimumRequiredStage;
        private readonly int currenStageValue;
        
        private int CompletedStageValue;
        public StudentWorkflowFilter(int minimumRequiredStage, int currenStageValue)
        {
            this.minimumRequiredStage = minimumRequiredStage;
            this.currenStageValue = currenStageValue;
            
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            int? sessionId = (int?)filterContext.HttpContext.Session.Contents["studentId"];
            IStudentInfoDataAccess studentInfo = new StudentInfoDataAccess();
            if (sessionId == null)
            {
                if (currenStageValue != (int)WorkflowValues.WorkFlow.ApplicantStage)
                {
                    filterContext.Result = new RedirectResult(urlHelper.Action("ApplicantInfo", "Applicant"));
                }
            }
            else if (sessionId != null)
            {
                CompletedStageValue = studentInfo.GetCurrentStageFromStudentInfo(sessionId);

                if ((currenStageValue > minimumRequiredStage) && (minimumRequiredStage == CompletedStageValue))
                {

                }
                else if (CompletedStageValue < minimumRequiredStage)
                {
                    switch (minimumRequiredStage)
                    {
                        case 10:
                            filterContext.Result = new RedirectResult(urlHelper.Action("ApplicantInfo", "Applicant"));
                            break;
                        case 20:
                            filterContext.Result = new RedirectResult(urlHelper.Action("AddressInfo", "Address"));
                            break;
                        case 30:
                            filterContext.Result = new RedirectResult(urlHelper.Action("QualificationInfo", "Qualification"));
                            break;
                    }
                }
            }
            //else
            //    filterContext.Result = new RedirectResult(urlHelper.Action("ApplicantInfo", "Applicant"));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.RequestType == "POST" && currenStageValue > CompletedStageValue && filterContext.Controller.ViewData.ModelState.IsValid)
            {
                IStudentInfoDataAccess studentInfo = new StudentInfoDataAccess();
                studentInfo.UpdateStudentInfoCompletedStage(currenStageValue, (int)filterContext.HttpContext.Session.Contents["studentId"]);
            }

        }
    }
}