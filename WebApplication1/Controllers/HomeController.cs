using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeadLock()
        {
            var result = CallApi().Result;
            ViewBag.Message = "Page";
            return View();
        }

        public ActionResult DeadLockFixed()
        {
            var result = CallApiWithFalse().Result;
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public async Task<HttpResponseMessage> CallApi()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://www.google.com");
            return response;
        }

        public async Task<HttpResponseMessage> CallApiWithFalse()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://www.google.com").ConfigureAwait(false);
            
            return response;
        }
    }
}