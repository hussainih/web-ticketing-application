using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ticketing.Helpers
{
    public static class HtmlExtensionsImage
    {
        public static MvcHtmlString Image(this HtmlHelper htmlHelper, string src, string altText) 
        {
            StringBuilder sb = new StringBuilder(512);

            sb.AppendFormat("<img src='{0}' alt='{1} />", src, altText);

            //HTML Ecode The string

            return MvcHtmlString.Create(sb.ToString());
            
        }
    }
}