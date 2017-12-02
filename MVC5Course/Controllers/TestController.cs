using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        FabricsEntities2 db = new FabricsEntities2();

        // GET: Test
        public ActionResult Index()
        {
            var data = from p in db.Product
                       select p;

            return View(data.Take(10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product data)
        {
            if(ModelState.IsValid)
            {
                db.Product.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var item = db.Product.Find(id);
            return View(item);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Product data)
        {
            if (ModelState.IsValid)
            {
                var item = db.Product.Find(id);
                item.ProductName = data.ProductName;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            var item = db.Product.Find(id);

            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = db.Product.Find(id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}