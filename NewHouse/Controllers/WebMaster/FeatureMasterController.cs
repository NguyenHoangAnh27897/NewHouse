using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers.WebMaster
{
    public class FeatureMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: FeatureMaster
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Feature.ToList(); ;
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string lang, string title, string content, string title1, string des1, string title2, string des2, string title3, string des3, string title4, string des4, string title5, string des5, string title6, string des6)
        {
            if (Session["Authentication"] != null)
            {
                var rs = new NH_Feature();
                if(lang == "vn")
                {
                    rs = db.NH_Feature.Find(1);
                }else if(lang == "en")
                {
                    rs = db.NH_Feature.Find(2);
                }
                rs.Title = title;
                rs.Description = content;
                rs.Title01 = title1;
                rs.Title02 = title2;
                rs.Title03 = title3;
                rs.Title04 = title4;
                rs.Title05 = title5;
                rs.Title06 = title6;
                rs.Description01 = des1;
                rs.Description02 = des2;
                rs.Description03 = des3;
                rs.Description04 = des4;
                rs.Description05 = des5;
                rs.Description06 = des6;
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "FeatureMaster");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}