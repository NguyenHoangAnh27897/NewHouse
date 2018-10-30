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
    public class ProjectMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: ProjectMaster
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lst = db.NH_Project.ToList(); ;
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
        public ActionResult Add(string title, string content, HttpPostedFileBase avatar, HttpPostedFileBase[] images, string lang, string kts)
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
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageproject"), fname);
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
                                var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageproject"), fname);
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
                int KTS = int.Parse(kts);
                var rs = new NH_Project();
                rs.ID = getGUID();
                rs.ProjectName = title;
                rs.Description = content;
                if (Avatar != "")
                {
                    rs.Avatar = Avatar;
                }
                if (Images != "")
                {
                    rs.Images = Images;
                }
                if(lang == "vn")
                {
                    rs.Language = "VN";
                }else if(lang == "en")
                {
                    rs.Language = "EN";
                }
                rs.ArchitectID = KTS;
                db.NH_Project.Add(rs);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }

        public ActionResult Edit(string id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Project.Where(s => s.ID.Equals(id));
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string ID,string title, string content, HttpPostedFileBase avatar, HttpPostedFileBase[] images, string kts)
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
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageproject"), fname);
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
                                var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageproject"), fname);
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
                int KTS = int.Parse(kts);
                var rs = db.NH_Project.Find(ID);
                rs.ProjectName = title;
                rs.Description = content;
                if (Avatar != "")
                {
                    rs.Avatar = Avatar;
                }
                if (Images != "")
                {
                    rs.Images = Images;
                }
                rs.ArchitectID = KTS;
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Project.Find(id);
                db.Entry(rs).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Webmaster");
        }

        //generate new id
        public static string getGUID()
        {
            string rs = "NEWHOUSE";
            Random rd = new Random();
            int random = rd.Next(90000);
            rs += random.ToString() + "_";
            random = rd.Next(90000);
            rs += random.ToString();
            return rs;
        }
    }
}