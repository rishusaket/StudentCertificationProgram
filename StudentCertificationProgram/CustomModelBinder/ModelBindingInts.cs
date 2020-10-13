using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

using System.Web.Mvc;

namespace StudentCertificationProgram.CustomModelBinder
{
    public class ModelBindingInts : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            var data = controllerContext.HttpContext.Request.QueryString["ids"];
            var b = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            List<int> model = new List<int>();
            string[] queryNumbers = data.Split(',');
            foreach (string num in queryNumbers)
            {
                int a = Int32.Parse(num);
                model.Add(a);
            }
            return model;

            //try
            //{
            //    var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            //    var value = valueResult.AttemptedValue;
            //    if(string.IsNullOrWhiteSpace(value))
            //    {
            //        return null;
            //    }
            //    var elementType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments;
            //    var converter = TypeDescriptor.GetConverter(elementType);

            //    var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            //                        .Select(x => converter.ConvertFromString(x.Trim()))
            //        .ToArray();

            //    var typedValues = Array.CreateInstance(elementType,values.Length);
            //    values.CopyTo(typedValues, 0);
            //    return typedValues;
            //}
            //catch(Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
        }
    }




















    public class ModelBindingIntsProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            var receivedContentType = "";
            if (! (receivedContentType == HttpContext.Current.Request.ContentType))
            {
                return null;
            }
            return new ModelBindingInts();
        }
    }
}