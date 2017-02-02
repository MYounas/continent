using continent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using AutoMapper;

namespace continent.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country

        DbcsContext db = new DbcsContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getData()
        {
            try
            {
                var data = db.countries.ToList();
               
                var lstData = Mapper.Map<IEnumerable<country>, IEnumerable<countryViewModel>>(data);

                return Json(new { Result = "OK", Records = lstData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }


        [HttpPost]
        public JsonResult Create(country c)
        {
            db.countries.Add(c);
            db.SaveChanges();
            return Json(new { Result = "OK", Record = c }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(country c)
        {
            db.countries.AddOrUpdate(c);
            db.SaveChanges();
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var data = db.countries.Find(id);
                db.countries.Remove(data);
                db.SaveChanges();
                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Result = "Error", Message = e.Message });
            }
        }
    }
}