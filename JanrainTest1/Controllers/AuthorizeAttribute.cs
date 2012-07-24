using System.Web.Mvc;

namespace JanrainTest1.Controllers
{
    public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var name = filterContext.HttpContext.User.Identity.Name;

            if (filterContext.HttpContext.Session != null)
            {
                var o = filterContext.HttpContext.Session["profile" + name];

                filterContext.Controller.ViewBag.User = o;
            }
        }
    }
}