using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewHouse.Controllers.WebMaster
{
    public class WebmasterController : Controller
    {
        // GET: Webmaster
        public ActionResult Index()
        {
            if (Session["Authentication"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (Username.Equals("admin"))
            {
                if (Password.Equals("newhouse"))
                {
                    Session["Authentication"] = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login", "Webmaster");
                }
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }

        }
        [HttpGet]
        public ActionResult Logout()
        {
            if (Session["Authentication"] != null)
            {
                return RedirectToAction("null");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}