using continent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using AutoMapper;


namespace continent.Controllers
{
    public class CityController : Controller
    {

        DbcsContext db = new DbcsContext();
        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getData()
        {
            var data = db.cities.ToList();
            var lstData = Mapper.Map<IEnumerable<city>, IEnumerable<cityViewModel>>(data);
            return Json(new { Result = "OK", Records = lstData }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCountriesOptions()
        {
            var data = db.countries.Select(c => new { DisplayText = c.name, Value = c.id });
            return Json(new { Result = "OK", Options = data });
        }

        [HttpPost]
        public ActionResult Create(city city)
        {
            db.cities.Add(city);
            db.SaveChanges();
            return Json(new { Result = "OK", Record = city },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(city c)
        {
            db.cities.AddOrUpdate(c);
            db.SaveChanges();
            return Json(new { Result = "OK"});
        }


        public ActionResult Delete(int Id)
        {
            db.cities.Remove(db.cities.Find(Id));
            db.SaveChanges();
            return Json(new { Result = "OK" });
        }

    }
}