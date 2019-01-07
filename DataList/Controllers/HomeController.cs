using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataList.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Persons()
        {
            var persons = Context.Persons.ToList();
            return View(persons);
        }
    }
}