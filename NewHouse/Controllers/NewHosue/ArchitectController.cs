using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers.NewHosue
{
    public class ArchitectController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: Architect
        public ActionResult Index(int id)
        {
            var rs = db.NH_Architec.Find(id);
            var lst = db.NH_Project.Where(s => s.ArchitectID == rs.ID).ToList();
            Architect ar = new Architect();
            ar.architect = rs;
            ar.project = lst;
            List<Architect> ls = new List<Architect>();
            ls.Add(ar);
            return View(ls);
        }
    }
}