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
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶Entities db = new 客戶Entities();

        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            var where = (客戶聯絡人)TempData["客戶聯絡人query_where"];

            if (TempData["客戶聯絡人query_action"] != null)
            {
                var query = from p in db.客戶聯絡人
                            where p.IsDeleted == false
                            select p;

                if (where.客戶Id != 0) query = query.Where(x => x.客戶Id.ToString().Contains(where.客戶Id.ToString()));
                if (!string.IsNullOrEmpty(where.職稱)) query = query.Where(x => x.職稱.Contains(where.職稱));
                if (!string.IsNullOrEmpty(where.姓名)) query = query.Where(x => x.姓名.ToString().Contains(where.姓名.ToString()));
                if (!string.IsNullOrEmpty(where.Email)) query = query.Where(x => x.Email.ToString().Contains(where.Email.ToString()));

                //var data = (IQueryable<客戶聯絡人>)TempData["客戶聯絡人query_result"];
                var data = query.ToList();
                if (data == null || data.Count() == 0)
                {
                    TempData["客戶聯絡人query_message"] = "查無資料，請修改查詢條件";
                    return RedirectToAction("Query");
                }
                else
                {
                    return View(data.AsQueryable().Include(客 => 客.客戶資料).Where(d => d.IsDeleted == false));
                }
            }
            else
            {
                var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料).Where(d => d.IsDeleted == false);
                return View(客戶聯絡人.ToList());
            }
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                db.客戶聯絡人.Add(客戶聯絡人);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶聯絡人).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Query([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            //客戶資料 客戶資料= new 客戶資料();
            //if (ModelState.IsValid)
            {
                var query = from p in db.客戶聯絡人
                            select p;

                TempData["客戶聯絡人query_where"] = 客戶聯絡人;
                TempData["客戶聯絡人query_action"] = true;
                return RedirectToAction("Index");
            }
            //return View(客戶資料);
        }
        // POST: 客戶聯絡人/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //if (客戶資料 == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(客戶資料);

            var item = db.客戶聯絡人.Find(id);
            item.IsDeleted = true;
            db.SaveChanges();
            TempData["客戶聯絡人Item"] = item;
            TempData["msg"] = "刪除成功";

            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
        //    db.客戶聯絡人.Remove(客戶聯絡人);
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
