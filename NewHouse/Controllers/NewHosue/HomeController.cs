using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers
{
    public class HomeController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        public ActionResult Index(int opt = 0)
        {
            if(opt == 0)
            {
                var slider = db.NH_Slider.Find(1);
                var solution = db.NH_Solution.Find(1);
                var home = db.NH_Homepage.Find(1);
                var feature = db.NH_Feature.Find(1);
                var project = db.NH_Project.Where(s=>s.Language == "VN").ToList();
                var newss = db.NH_News.Where(s=>s.Language == "VN").ToList();
                var partnership = db.NH_Partnership.Find(1);
                var architect = db.NH_Architec.Where(s=>s.Language == "VN").ToList();
                var partner = db.NH_Partner.Where(s=>s.Language == "VN").ToList();
                var about = db.NH_AboutUs.Find(1);
                Data dt = new Data();
                dt.ab = about;
                dt.fea = feature;
                dt.hp = home;
                dt.pro = project;
                dt.sol = solution;
                dt.slider = slider;
                dt.news = newss;
                dt.pn = partner;
                dt.pns = partnership;
                dt.ar = architect;
                List<Data> lst = new List<Data>();
                lst.Add(dt);
                ViewBag.OPT = 0;
                return View(lst);
            }
            else
            {
                var slider = db.NH_Slider.Find(2);
                var solution = db.NH_Solution.Find(2);
                var home = db.NH_Homepage.Find(2);
                var feature = db.NH_Feature.Find(2);
                var project = db.NH_Project.Where(s => s.Language == "EN").ToList();
                var newss = db.NH_News.Where(s => s.Language == "EN").ToList();
                var partnership = db.NH_Partnership.Find(2);
                var architect = db.NH_Architec.Where(s => s.Language == "EN").ToList();
                var partner = db.NH_Partner.Where(s => s.Language == "EN").ToList();
                var about = db.NH_AboutUs.Find(2);
                Data dt = new Data();
                dt.ab = about;
                dt.fea = feature;
                dt.hp = home;
                dt.pro = project;
                dt.sol = solution;
                dt.slider = slider;
                dt.news = newss;
                dt.pn = partner;
                dt.pns = partnership;
                dt.ar = architect;
                List<Data> lst = new List<Data>();
                lst.Add(dt);
                ViewBag.OPT = 1;
                return View(lst);
            }
           
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name, string email, string subject, string mess)
        {
            var rs = new NH_Contact();
            rs.Name = name;
            rs.Email = email;
            rs.Subject = subject;
            rs.Description = mess;
            db.NH_Contact.Add(rs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}