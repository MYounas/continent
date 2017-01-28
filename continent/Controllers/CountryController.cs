using continent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using Newtonsoft.Json;

namespace continent.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country

        DbcsContext db = new DbcsContext();
        public ActionResult Index()
        {
            //return View(db.countries.ToList());
            return View();
        }

        public JsonResult getData()
        {

            try
            {
                var data = db.countries.ToList();
                List<countryViewModel> lstData = new List<countryViewModel>();
                foreach (var d in data)
                {
                    lstData.Add(new countryViewModel
                    {
                        id = d.id,
                        name = d.name
                    });
                }

                var jsonData = JsonConvert.SerializeObject(lstData);

                return Json(new { Result = "OK", Records = lstData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(country c)
        {
            db.countries.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            return View(db.countries.Single(x => x.id == Id));
        }

        [HttpPost]
        public ActionResult Edit(country c)
        {
            db.countries.AddOrUpdate(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var data = db.countries.Find(Id);
            db.countries.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}