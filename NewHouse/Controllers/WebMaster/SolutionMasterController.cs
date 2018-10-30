using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers.WebMaster
{
    public class SolutionMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: SolutionMaster
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Solution.ToList();
                return View(rs);
            }
            return RedirectToAction("Login","Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string title, string content, string lang)
        {
            if (Session["Authentication"] != null)
            {
                var rs = new NH_Solution();
                if(lang == "vn")
                {
                    rs = db.NH_Solution.Find(1);
                }
                else if(lang == "en")
                {
                    rs = db.NH_Solution.Find(2);
                }
                rs.Title = title;
                rs.SolutionContent = content;
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "SolutionMaster");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}