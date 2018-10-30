using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers.NewHosue
{
    public class ProjectController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: Project
        public ActionResult Detail(string id)
        {
            var rs = db.NH_Project.Find(id);
            return View(rs);
        }
    }
}