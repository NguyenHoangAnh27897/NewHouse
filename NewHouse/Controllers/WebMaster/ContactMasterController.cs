using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;
using PagedList;
using PagedList.Mvc;

namespace NewHouse.Controllers.WebMaster
{
    public class ContactMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: ContactMaster
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var rs = db.NH_Contact.ToList();
                return View(rs.ToPagedList(pageNumber,pageSize));
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Contact.Find(id);
                db.Entry(rs).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}