using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertification_Entities
{
    public class WorkflowValues
    {
        public enum WorkFlow
        {
            Default = 0,
            ApplicantStage = 10,
            AddressStage = 20,
            EducationStage = 30
        }
    }
}
