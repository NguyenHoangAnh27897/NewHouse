using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewHouse.Models;

namespace NewHouse.Controllers.NewHosue
{
    public class HouseController : Controller
    {
        NewHouseEntities db = new NewHouseEntities();
        // GET: House
        public ActionResult DetailFirst()
        {
            var rs = db.NH_Homepage.Find(1);
            return View(rs);
        }
    }
}