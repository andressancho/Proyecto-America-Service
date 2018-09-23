using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmericanService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string userid, string pwd) //Formal Parameters  
        {
            string username = userid;
            string password = pwd;
            if (username == "Admin" && password == "123456")
            {
                Response.Write("<h2> Success </h2> Valid User...");

            }
            else
            {
                Response.Write(" <h2> Failed </h2> Invalid User...");
                return View("About");
            }
            return View("Index");
        }
    }
}