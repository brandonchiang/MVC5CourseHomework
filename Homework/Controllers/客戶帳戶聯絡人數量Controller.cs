using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework.Models;

namespace Homework.Controllers
{
    public class 客戶帳戶聯絡人數量Controller : Controller
    {
        private 客戶Entities db = new 客戶Entities();

        // GET: 客戶帳戶聯絡人數量
        public ActionResult Index()
        {
            return View(db.客戶帳戶聯絡人數量.ToList());
        }

        // GET: 客戶帳戶聯絡人數量/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶帳戶聯絡人數量 客戶帳戶聯絡人數量 = db.客戶帳戶聯絡人數量.Find(id);
            if (客戶帳戶聯絡人數量 == null)
            {
                return HttpNotFound();
            }
            return View(客戶帳戶聯絡人數量);
        }

        //// GET: 客戶帳戶聯絡人數量/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: 客戶帳戶聯絡人數量/Create
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,客戶名稱,銀行帳戶數量,聯絡人數量")] 客戶帳戶聯絡人數量 客戶帳戶聯絡人數量)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.客戶帳戶聯絡人數量.Add(客戶帳戶聯絡人數量);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(客戶帳戶聯絡人數量);
        //}

        //// GET: 客戶帳戶聯絡人數量/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    客戶帳戶聯絡人數量 客戶帳戶聯絡人數量 = db.客戶帳戶聯絡人數量.Find(id);
        //    if (客戶帳戶聯絡人數量 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(客戶帳戶聯絡人數量);
        //}

        //// POST: 客戶帳戶聯絡人數量/Edit/5
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,客戶名稱,銀行帳戶數量,聯絡人數量")] 客戶帳戶聯絡人數量 客戶帳戶聯絡人數量)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(客戶帳戶聯絡人數量).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(客戶帳戶聯絡人數量);
        //}

        // GET: 客戶帳戶聯絡人數量/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶帳戶聯絡人數量 客戶帳戶聯絡人數量 = db.客戶帳戶聯絡人數量.Find(id);
            if (客戶帳戶聯絡人數量 == null)
            {
                return HttpNotFound();
            }
            return View(客戶帳戶聯絡人數量);
        }

        //// POST: 客戶帳戶聯絡人數量/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    客戶帳戶聯絡人數量 客戶帳戶聯絡人數量 = db.客戶帳戶聯絡人數量.Find(id);
        //    db.客戶帳戶聯絡人數量.Remove(客戶帳戶聯絡人數量);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
