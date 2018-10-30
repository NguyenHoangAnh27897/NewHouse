using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers.WebMaster
{
    public class SliderMasterController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: SliderMaster
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.NH_Slider.ToList();
                return View(rs);
            }
            return RedirectToAction("Login", "Webmaster");
        }

        [HttpPost]
        public ActionResult Edit(string lang,string title1, string subtitle1, HttpPostedFileBase image1, string title2, string subtitle2, HttpPostedFileBase image2, string title3, string subtitle3, HttpPostedFileBase image3, string title4, string subtitle4, HttpPostedFileBase image4, string title5, string subtitle5, HttpPostedFileBase image5, string title6, string subtitle6, HttpPostedFileBase image6)
        {
            if (Session["Authentication"] != null)
            {
                string Image1 = "";
                if (image1 != null)
                {
                    if (image1.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image1.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageslider"), fname);
                        image1.SaveAs(path);
                        Image1 += fname;
                    }

                }
                string Image2 = "";
                if (image2 != null)
                {
                    if (image2.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image2.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageslider"), fname);
                        image2.SaveAs(path);
                        Image2 += fname;
                    }

                }
                string Image3 = "";
                if (image3 != null)
                {
                    if (image3.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image3.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageslider"), fname);
                        image3.SaveAs(path);
                        Image3 += fname;
                    }

                }
                string Image4 = "";
                if (image4 != null)
                {
                    if (image4.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image4.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageslider"), fname);
                        image4.SaveAs(path);
                        Image4 += fname;
                    }

                }
                string Image5 = "";
                if (image5 != null)
                {
                    if (image5.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image5.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageslider"), fname);
                        image5.SaveAs(path);
                        Image5 += fname;
                    }

                }
                string Image6 = "";
                if (image6 != null)
                {
                    if (image6.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image6.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/NewHouse/imageslider"), fname);
                        image6.SaveAs(path);
                        Image6 += fname;
                    }

                }
                var rs = new NH_Slider();
                if(lang == "vn")
                {
                    rs = db.NH_Slider.Find(1);
                }
                else if(lang == "en")
                {
                    rs = db.NH_Slider.Find(2);
                }
                rs.Title01 = title1;
                rs.Title02 = title2;
                rs.Title03 = title3;
                rs.Title04 = title4;
                rs.Title05 = title5;
                rs.Title06 = title6;
                rs.SubTitle01 = subtitle1;
                rs.SubTitle02 = subtitle2;
                rs.SubTitle03 = subtitle3;
                rs.SubTitle04 = subtitle4;
                rs.SubTitle05 = subtitle5;
                rs.SubTitle06 = subtitle6;
                if (Image1 != "")
                {
                    rs.Image01 = Image1;
                }
                if (Image2 != "")
                {
                    rs.Image02 = Image2;
                }
                if (Image3 != "")
                {
                    rs.Image03 = Image3;
                }
                if (Image4 != "")
                {
                    rs.Image04 = Image4;
                }
                if (Image5 != "")
                {
                    rs.Image05 = Image5;
                }
                if (Image6 != "")
                {
                    rs.Image06 = Image6;
                }
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return RedirectToAction("Login", "Webmaster");
        }
    }
}