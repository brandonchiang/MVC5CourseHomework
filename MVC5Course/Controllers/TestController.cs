using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        //ProductRepository repo = new ProductRepository();

        // GET: Test
        public ActionResult Index()
        {
            //var data = repo.Get取得所有未刪除的商品資料();
            var data = repo.All();

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
                repo.Add(data);
                repo.UnitOfWork.Commit();

                TempData["ProductItem"] = data;
                TempData["msg"] = "新增成功";

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        { 
            var item = repo.Find(id);
            return View(item);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Product data)
        {
            if (ModelState.IsValid)
            {
                var item =repo.Find(id);

                item.ProductName = data.ProductName;
                item.Price = data.Price;
                item.Stock = data.Stock;
                item.Active = data.Active;

                repo.UnitOfWork.Commit();

                TempData["ProductItem"] = item;
                TempData["msg"] = "修改成功";

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            var item = repo.Find(id);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = repo.Find(id);

            //db.OrderLine.RemoveRange(item.OrderLine.ToList());
            //db.Product.Remove(item);

            item.IsDeleted = true;

            repo.UnitOfWork.Commit();
            TempData["ProductItem"] = item;
            TempData["msg"] = "刪除成功";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            //db.Product.Remove(product);
            //db.Product.Remove(product);
            product.IsDeleted = false;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}