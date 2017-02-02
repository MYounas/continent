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

        [HttpPost]
        public ActionResult Create(area a)
        {
            db.areas.Add(a);
            db.SaveChanges();
            return Json(new { Result = "OK", Records = a });
        }

        [HttpPost]
        public ActionResult Edit(area a)
        {
            db.areas.AddOrUpdate(a);
            db.SaveChanges();
            return Json(new { Result = "OK" });
        }

        public ActionResult Delete(int id)
        {
            var area = db.areas.Find(id);
            db.areas.Remove(area);
            db.SaveChanges();
            return Json(new { Result = "OK" });
        }

    }
}