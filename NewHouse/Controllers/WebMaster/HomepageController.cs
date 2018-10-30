using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers.WebMaster
{
    public class HomepageController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: Homepage
        public ActionResult Index()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Homepage.ToList();
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string lang, string title, string content, string title1, string des1, HttpPostedFileBase image1, string title2, string des2, HttpPostedFileBase image2, string title3, string des3, HttpPostedFileBase image3, string title4, string des4, HttpPostedFileBase image4)
        {
            if (Session["Authentication"] != null)
            {
                string Images1 = "";
                if (image1 != null)
                {
                    if (image1.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image1.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagehomepage"), fname);
                        image1.SaveAs(path);
                        Images1 += fname;
                    }
                }

                string Images2 = "";
                if (image2 != null)
                {
                    if (image2.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image2.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagehomepage"), fname);
                        image2.SaveAs(path);
                        Images2 += fname;
                    }
                }
                string Images3 = "";
                if (image3 != null)
                {
                    if (image3.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image3.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagehomepage"), fname);
                        image3.SaveAs(path);
                        Images3 += fname;
                    }
                }
                string Images4 = "";
                if (image4 != null)
                {
                    if (image4.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image4.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imagehomepage"), fname);
                        image4.SaveAs(path);
                        Images4 += fname;
                    }
                }
                NH_Homepage rs = new NH_Homepage();
                if(lang == "vn")
                {
                    rs = db.NH_Homepage.Find(1);
                }
                else if(lang == "en")
                {
                    rs = db.NH_Homepage.Find(2);
                }             
                rs.Title01 = title;
                rs.Description = content;
                rs.Description01 = des1;
                rs.Description02 = des2;
                rs.Description03 = des3;
                rs.Description04 = des4;
                rs.SubTitle01 = title1;
                rs.SubTitle02 = title2;
                rs.SubTitle03 = title3;
                rs.SubTitle04 = title4;
                if (Images1 != "")
                {
                    rs.Image01 = Images1;
                }
                if (Images2 != "")
                {
                    rs.Image02 = Images2;
                }
                if (Images3 != "")
                {
                    rs.Image03 = Images3;
                }
                if (Images4 != "")
                {
                    rs.Image04 = Images4;
                }
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Homepage");
            }
            return RedirectToAction("Login", "Webmaster");
        }

        public ActionResult EditContact()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_AboutUs.ToList();
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        public ActionResult EditContact(string address, string email, string phone, string lang)
        {
            if (Session["Authentication"] != null)
            {
                var rs = new NH_AboutUs();
                if(lang == "vn")
                {
                    rs = db.NH_AboutUs.Find(1);
                }
                else if(lang == "en")
                {
                    rs = db.NH_AboutUs.Find(2);
                }              
                rs.Address = address;
                rs.Email = email;
                rs.Phone = phone;
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditContact");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}