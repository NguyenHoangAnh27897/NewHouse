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
    public class NewsMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: NewsMaster
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lst = db.NH_News.ToList(); ;
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
        public ActionResult Add(string title, string content, HttpPostedFileBase avatar, HttpPostedFileBase[] images, string lang)
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
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagenews"), fname);
                        avatar.SaveAs(path);
                        Avatar += fname;
                    }

                }
                string Images = "";
                if (images != null)
                {
                    foreach (HttpPostedFileBase file in images)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(file.FileName);
                                var fname = filename.Replace(" ", "_");
                                var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagenews"), fname);
                                file.SaveAs(path);
                                Images += fname + ",";
                            }
                        }
                    }
                    if (Images != "" && Images.Contains(","))
                    {
                        Images = Images.Remove(Images.Length - 1);
                    }
                }
                var rs = new NH_News();
                rs.Title = title;
                rs.Description = content;
                if (Avatar != "")
                {
                    rs.Avatar = Avatar;
                }
                if (Images != "")
                {
                    rs.Images = Images;
                }
                if (lang == "vn")
                {
                    rs.Language = "VN";
                }
                else if (lang == "en")
                {
                    rs.Language = "EN";
                }
                db.NH_News.Add(rs);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }

        public ActionResult Edit(int id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_News.Where(s => s.ID == id);
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string ID, string title, string content, HttpPostedFileBase avatar, HttpPostedFileBase[] images)
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
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagenews"), fname);
                        avatar.SaveAs(path);
                        Avatar += fname;
                    }

                }
                string Images = "";
                if (images != null)
                {
                    foreach (HttpPostedFileBase file in images)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(file.FileName);
                                var fname = filename.Replace(" ", "_");
                                var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagenews"), fname);
                                file.SaveAs(path);
                                Images += fname + ",";
                            }
                        }
                    }
                    if (Images != "" && Images.Contains(","))
                    {
                        Images = Images.Remove(Images.Length - 1);
                    }
                }
                int id = int.Parse(ID);
                var rs = db.NH_News.Find(id);
                rs.Title = title;
                rs.Description = content;
                if (Avatar != "")
                {
                    rs.Avatar = Avatar;
                }
                if (Images != "")
                {
                    rs.Images = Images;
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
                var rs = db.NH_News.Find(id);
                db.Entry(rs).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}