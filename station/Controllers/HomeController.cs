using station.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace station.Controllers
{
    public class HomeController : Controller
    {
        private StationContext db = new StationContext();

        public ActionResult Index()
        {
            return View(db.Stations.ToList());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}