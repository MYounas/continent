using continent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace continent.Controllers
{
    public class AreaController : Controller
    {
        DbcsContext db = new DbcsContext();
        // GET: Area
        public ActionResult Index()
        {
            return View(db.areas.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CO_id = new SelectList(db.countries, "id", "name");
            //ViewBag.CI_id = new SelectList(db.cities, "id", "name");
            ViewBag.CI_id = new SelectList(new List<string>(), "id", "name");
            //ViewBag.CI_id = new SelectList();
            return View();
        }

        public JsonResult getCities(int? CID)
        {
            var data= new SelectList(db.countries.Find(CID).cities, "id", "name");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(area a)
        {
            db.areas.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}