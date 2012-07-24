using System.Web.Mvc;

namespace JanrainTest1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [Authorize]
        public ViewResult SecurePage()
        {
            return View(Session["profile"]);
        }

        [Authorize]
        public ViewResult AnotherSecurePage()
        {
            return View("SecurePage", Session["profile"]);
        }
    }
}