using System.Web.Mvc;
using System.Web.Security;
using JanrainTest1.Models;
using RestSharp;

namespace JanrainTest1.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string ReturnUrl)
        {
            return View((object) ReturnUrl);
        }

        [HttpPost]
        public ActionResult ProcessLogin(string token, string ReturnUrl)
        {
            if (string.IsNullOrEmpty(token))
            {
                return View("Login");
            }
            try
            {
                var client = new RestClient("https://rpxnow.com/");
                var request = new RestRequest("api/v2/auth_info");
                request.AddParameter("token", token);
                request.AddParameter("apiKey", "foo");

                // client.Proxy = new WebProxy("127.0.0.1", 5865);

                var response = client.Execute<AuthInfo>(request);

                if (response != null && response.Data != null && response.Data.IsOk())
                {
                    Session["profile" + response.Data.profile.identifier] = response.Data.profile;

                    FormsAuthentication.SetAuthCookie(response.Data.profile.identifier, false);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch
            {
                return RedirectToAction("Login");
            }

            var url = Url.IsLocalUrl(ReturnUrl) ? ReturnUrl : "~/";

            return Redirect(url);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}