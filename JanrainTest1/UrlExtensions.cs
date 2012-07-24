using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JanrainTest1
{
    public static class UrlExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string action, string controller, string ReturnUrl)
        {
            var relativeUrl = url.Action(action, controller, new {ReturnUrl});
            string root = url.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
            return root + VirtualPathUtility.ToAbsolute("~/" + relativeUrl);
        }
    }
}