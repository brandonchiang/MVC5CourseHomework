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
    public class 客戶銀行資訊Controller : Controller
    {
        private 客戶Entities db = new 客戶Entities();

        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            //db.Configuration.LazyLoadingEnabled = false;
            var where =(客戶銀行資訊)TempData["客戶銀行資訊query_where"] ;
            
            if (TempData["客戶銀行資訊query_action"] != null)
            {
                var query = from p in db.客戶銀行資訊
                            select p;

                if (where.客戶Id != 0) query = query.Where(x => x.客戶Id.ToString().Contains(where.客戶Id.ToString()));
                if (!string.IsNullOrEmpty(where.銀行名稱)) query = query.Where(x => x.銀行名稱.Contains(where.銀行名稱));
                if (where.銀行代碼 != 0) query = query.Where(x => x.銀行代碼.ToString().Contains(where.銀行代碼.ToString()));
                if (where.分行代碼 != null) query = query.Where(x => x.分行代碼.ToString().Contains(where.分行代碼.ToString()));
                if (!string.IsNullOrEmpty(where.帳戶名稱)) query = query.Where(x => x.帳戶名稱.Contains(where.帳戶名稱));
                if (!string.IsNullOrEmpty(where.帳戶號碼)) query = query.Where(x => x.帳戶號碼.Contains(where.帳戶號碼));

                //var data = (IQueryable<客戶銀行資訊>)TempData["客戶銀行資訊query_result"];
                var data = query.ToList();
                if (data == null || data.Count() == 0)
                {
                    TempData["客戶銀行資訊query_message"] = "查無資料，請修改查詢條件";
                    return RedirectToAction("Query");
                }
                else
                {
                    return View(data.AsQueryable().Include(客 => 客.客戶資料));
                }
            }
            else
            {
                TempData["客戶銀行資訊query_action"] = false;
                var 客戶銀行資訊 = db.客戶銀行資訊.Include(客 => 客.客戶資料);
                return View(客戶銀行資訊.ToList());
            }
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                db.客戶銀行資訊.Add(客戶銀行資訊);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶銀行資訊).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Query([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            //客戶資料 客戶資料= new 客戶資料();
            //if (ModelState.IsValid)
            {
                var query = from p in db.客戶銀行資訊
                            select p;
                            //{
                            //    p.Id,
                            //    p.客戶Id,
                            //    p.銀行名稱,
                            //    p.銀行代碼,
                            //    p.分行代碼,
                            //    p.帳戶名稱,
                            //    p.帳戶號碼,
                            //    p.客戶資料
                            //};

                //return View(result);
                //TempData["客戶銀行資訊query_result"] = query.ToList().AsQueryable<客戶銀行資訊>();
                TempData["客戶銀行資訊query_where"] = 客戶銀行資訊;
                TempData["客戶銀行資訊query_action"] = true;
                return RedirectToAction("Index");
            }
            //return View(客戶資料);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            db.客戶銀行資訊.Remove(客戶銀行資訊);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
