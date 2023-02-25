using labtaskweek5.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labtaskweek5.Controllers
{
    public class HomeController : Controller
    {
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

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(product model)
        {
            var db = new lab5Entities1();
            db.products.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            var db = new lab5Entities1();
            var products = db.products.ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var db = new lab5Entities1();
            var product = (from p in db.products where p.id == id select p).SingleOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new lab5Entities1();
            var product = (from p in db.products where p.id == id select p).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(product model)
        {
            var db = new lab5Entities1();
            var exst = (from p in db.products where p.id == model.id select p).SingleOrDefault();
            db.Entry(exst).CurrentValues.SetValues(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var db = new lab5Entities1();
            var st = (from p in db.products where p.id == id select p).SingleOrDefault();
            db.products.Remove(st);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}