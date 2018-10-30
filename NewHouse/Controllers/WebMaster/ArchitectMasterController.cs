using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;
using PagedList;
using PagedList.Mvc;

namespace NewHouse.Controllers.WebMaster
{
    public class ArchitectMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: ArchitectMaster
        public ActionResult List(int? page = 1)
        {
            NewHouseEntities db = new NewHouseEntities();
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lst = db.NH_Architec.ToList();
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            return RedirectToAction("Login", "Webmaster");
        }

        public ActionResult Add()
        {
            if (Session["Authentication"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string name, string des, HttpPostedFileBase avatar, string lang)
        {
            if (Session["Authentication"] != null)
            {
                string Avatar = "";
                if (avatar != null)
                {
                    if (avatar.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(avatar.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagearchitec"), fname);
                        avatar.SaveAs(path);
                        Avatar += fname;
                    }

                }
                var rs = new NH_Architec();
                rs.Name = name;
                rs.Description = des;
                if (Avatar != "")
                {
                    rs.Avatar = Avatar;
                }
                if (lang == "vn")
                {
                    rs.Language = "VN";
                }
                else if (lang == "en")
                {
                    rs.Language = "EN";
                }
                db.NH_Architec.Add(rs);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }
        public ActionResult Edit(int id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Architec.Find(id);
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string ID, string name, string des, HttpPostedFileBase avatar)
        {
            if (Session["Authentication"] != null)
            {
                string Avatar = "";
                if (avatar != null)
                {
                    if (avatar.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(avatar.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagearchitec"), fname);
                        avatar.SaveAs(path);
                        Avatar += fname;
                    }

                }
                int id = int.Parse(ID);
                var rs = db.NH_Architec.Find(id);
                rs.Name = name;
                rs.Description = des;
                if (Avatar != "")
                {
                    rs.Avatar = Avatar;
                }
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Architec.Find(id);
                db.Entry(rs).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}