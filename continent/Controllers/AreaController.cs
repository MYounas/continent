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
    public class AreaController : Controller
    {
        DbcsContext db = new DbcsContext();
        // GET: Area
        public ActionResult Index()
        {
            //return View(db.areas.ToList());
            return View();
        }

        public JsonResult getData()
        {
            var data = db.areas.ToList();
            var lstData = Mapper.Map<IEnumerable<area>, IEnumerable<areaViewModel>>(data);
            return Json(new { Result = "OK", Records = lstData }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getCountriesOptions()
        {
            var data = db.countries.Select(c => new { DisplayText = c.name, Value = c.id });
            return Json(new { Result = "OK", Options = data });
        }
        public JsonResult getCitiesOptions(int CO_id)
        {
            var data = new object();
            if(CO_id!=0)
                data = db.cities.Where(x => x.CO_id == CO_id).Select(c => new { DisplayText = c.name, Value = c.id });
            else
                data = db.cities.Select(c => new { DisplayText = c.name, Value = c.id });
            return Json(new { Result = "OK", Options = data });
        }

        //public JsonResult getCitiesOptions()
        //{
        //    var data = db.cities.Select(c => new { DisplayText = c.name, Value = c.id });
        //    return Json(new { Result = "OK", Options = data });
        //}

        //public ActionResult Create()
        //{
        //    ViewBag.CO_id = new SelectList(db.countries, "id", "name");
        //    ViewBag.CI_id = new SelectList(new List<string>(), "id", "name");
        //    return View();
        //}

        //public JsonResult getCities(int? CID)
        //{
        //    var data= new SelectList(db.countries.Find(CID).cities, "id", "name");
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult Create(area a)
        {
            db.areas.Add(a);
            db.SaveChanges();
            return Json(new { Result = "OK", Records = a });
            //return RedirectToAction("Index");
        }

        //public ActionResult Edit(int id)
        //{
        //    var area = db.areas.Find(id);
        //    var co_id = db.cities.Find(area.CI_id).CO_id;

        //    var cities = db.cities.Where(x => x.CO_id == co_id);

        //    ViewBag.CO_id = new SelectList(db.countries, "id", "name",co_id);
        //    ViewBag.CI_id = new SelectList(cities, "id", "name", area.CI_id);
        //    return View(area);
        //}

        [HttpPost]
        public ActionResult Edit(area a)
        {
            db.areas.AddOrUpdate(a);
            db.SaveChanges();
            return Json(new { Result = "OK" });
            //return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var area = db.areas.Find(id);
            db.areas.Remove(area);
            db.SaveChanges();
            return Json(new { Result = "OK" });
            //return RedirectToAction("Index");
        }

    }
}