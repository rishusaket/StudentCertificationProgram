using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace StudentCertificationProgram.CustomModelBinder
{
    public class XMLModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = bindingContext.ModelType;
            var data = new XmlSerializer(model);
            var receivedStream = controllerContext.HttpContext.Request.InputStream;
            return data.Deserialize(receivedStream);
        }
    }
        public class XMLModelBinderProvider : IModelBinderProvider
        {
            public IModelBinder GetBinder(Type modelType)
            {
                var receivedContentType = HttpContext.Current.Request.ContentType.ToLower();
                if (receivedContentType != "text/xml")
                {
                    return null;
                }
                return new XMLModelBinder();
            }
        }
    
}