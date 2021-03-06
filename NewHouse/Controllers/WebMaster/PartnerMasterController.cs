﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using NewHouse.Models;
using System.IO;

namespace NewHouse.Controllers.WebMaster
{
    public class PartnerMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: PartnerMaster
        public ActionResult EditArchitect()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Partnership.ToList();
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditArchitect(string title, string des, string lang)
        {
            if (Session["Authentication"] != null)
            {
                var rs = new NH_Partnership();
                if (lang == "vn")
                {
                    rs = db.NH_Partnership.Find(1);
                }
                else if (lang == "en")
                {
                    rs = db.NH_Partnership.Find(2);
                }
                rs.Title = title;
                rs.Description = des;
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditArchitect");
            }
            return RedirectToAction("Login", "Webmaster");
        }
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lst = db.NH_Partner.ToList(); ;
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
        public ActionResult Add(string name, string link, HttpPostedFileBase avatar, string lang)
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
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagepartner"), fname);
                        avatar.SaveAs(path);
                        Avatar += fname;
                    }

                }
                var rs = new NH_Partner();
                rs.Name = name;
                rs.Link = link;
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
                db.NH_Partner.Add(rs);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }

        public ActionResult Edit(int id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Partner.Find(id);
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string name, string link, HttpPostedFileBase avatar, string ID)
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
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagepartner"), fname);
                        avatar.SaveAs(path);
                        Avatar += fname;
                    }

                }
                int id = int.Parse(ID);
                var rs = db.NH_Partner.Find(id);
                rs.Name = name;
                rs.Link = link;
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
                var rs = db.NH_Partner.Find(id);
                db.Entry(rs).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}