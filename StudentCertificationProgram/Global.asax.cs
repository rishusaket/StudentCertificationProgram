using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using StudentCertification_BusinessAccessLayer;
using StudentCertification_DataAccessLayer;
using StudentCertificationProgram.App_Start;
using StudentCertificationProgram.Controllers;
using StudentCertificationProgram.CustomModelBinder;
using static StudentCertificationProgram.CustomModelBinder.XMLModelBinder;

namespace StudentCertificationProgram
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinderProviders.BinderProviders.Insert(0, new ModelBindingIntsProvider());
            ModelBinderProviders.BinderProviders.Insert(0, new XMLModelBinderProvider());
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MyCustomViewEngine());
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterType<StudentInfoDataAccess>().As<IStudentInfoDataAccess>().InstancePerRequest();
            builder.RegisterType<StudentAddressDataAccess>().As<IStudentAddressDataAccess>().InstancePerRequest();
            builder.RegisterType<StudentEducationDataAccess>().As<IStudentEducationDataAccess>().InstancePerRequest();
            builder.RegisterType<StudentDecisionDataAccess>().As<IStudentDecisionDataAccess>().InstancePerRequest();

            builder.RegisterType<StudentInfoBusinessAccess>().As<IStudentInfoBusinessAccess>().InstancePerRequest();
            builder.RegisterType<StudentAddressBusinessAccess>().As<IStudentAddressBusinessAccess>().InstancePerRequest();
            builder.RegisterType<StudentEducationBusinessAccess>().As<IStudentEducationBusinessAccess>().InstancePerRequest();
            builder.RegisterType<StudentDecisionBusinessAccess>().As<IStudentDecisionBusinessAccess>().InstancePerRequest();

            builder.RegisterControllers(typeof(ApplicantController).Assembly).InstancePerRequest();
            builder.RegisterType<AddressController>().InstancePerRequest();
            builder.RegisterType<QualificationController>().InstancePerRequest();
            builder.RegisterType<DecisionController>().InstancePerRequest();


            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
