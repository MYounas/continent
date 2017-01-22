using continent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using System.Data.Entity;


namespace continent.Controllers
{
    public class CityController : Controller
    {

        DbcsContext db = new DbcsContext();
        // GET: City
        public ActionResult Index()
        {
            return View(db.cities.ToList());
        }

        public ActionResult Create()
        {
            var CCV = new CountryCityViewModel
            {
                City = new city(),
                Countries = db.countries.ToList()
            };
            return View(CCV);
        }

        [HttpPost]
        public ActionResult Create(CountryCityViewModel CCV)
        {
            db.cities.Add(CCV.City);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var city = db.cities.Find(Id);
            ViewBag.CO_id = new SelectList(db.countries, "id", "name", city.CO_id);
            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(city c)
        {
            //db.Entry(c).State = EntityState.Modified;
            db.cities.AddOrUpdate(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            db.cities.Remove(db.cities.Find(Id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}