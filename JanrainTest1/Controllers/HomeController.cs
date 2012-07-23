using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestSharp;

namespace JanrainTest1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        public ViewResult SecurePage(string token)
        {
            var client = new RestClient("https://rpxnow.com/");
            var request = new RestRequest("api/v2/auth_info");
            request.AddParameter("token", token);
            request.AddParameter("apiKey", "EEEEENTERER");
//            client.Proxy = new WebProxy("127.0.0.1", 5865);
            var response = client.Execute<AuthInfo>(request);
            
            return View(response.Data);
        }
    }

    public static class UrlExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string action)
        {
            var relativeUrl =  url.Action(action);
            string root = url.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
            return root + VirtualPathUtility.ToAbsolute("~/" + relativeUrl);
        }
    }

    public class Name
    {
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string formatted { get; set; }
    }

    public class Profile
    {
        public string url { get; set; }
        public string preferredUsername { get; set; }
        public string email { get; set; }
        public Name name { get; set; }
        public string photo { get; set; }
        public string displayName { get; set; }
        public string identifier { get; set; }
        public string verifiedEmail { get; set; }
        public string providerName { get; set; }
        public string googleUserId { get; set; }
    }

    public class AuthInfo
    {
        public string stat { get; set; }
        public Profile profile { get; set; }
    }
}