using continent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

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
            return Json(new { Result = "OK", Records = c }, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Edit(int Id)
        //{
        //    return View(db.countries.Single(x => x.id == Id));
        //}

        [HttpPost]
        public JsonResult Edit(country c)
        {
            db.countries.AddOrUpdate(c);
            db.SaveChanges();
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var data = db.countries.Find(id);
                db.countries.Remove(data);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception e)
            {
                return Json(new { Result = "Error",Message=e.Message });
            }
            //return RedirectToAction("Index");
        }
    }
}