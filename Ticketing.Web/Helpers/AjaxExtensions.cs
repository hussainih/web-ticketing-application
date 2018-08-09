using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Ticketing.Helpers
{
    public static class AjaxExtensions
    {
        public static MvcHtmlString SpanActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var newLinkText = "<span style = 'font-family:Helvetica Neue, Helvetica, Arial, sans-serif !important;' >" + linkText + "</ span >";
             var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, newLinkText));
        }
        
    }
}