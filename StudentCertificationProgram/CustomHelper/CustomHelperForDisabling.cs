using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentCertificationProgram.CustomHelper
{
    
    public static class CustomHelperForDisabling
    {
        public static IHtmlString htmlString(this HtmlHelper helper, string path, int? enable, string text)
        {
            TagBuilder tb = new TagBuilder("a");
           
            tb.SetInnerText(text);
                        
            if (enable != null)
            {
                tb.Attributes.Add("href", path);
                tb.AddCssClass("style='color:#FF0000'");
                return new HtmlString(tb.ToString());
            }
            else
            {
                return new HtmlString(tb.ToString());
            }
        }
    }
}