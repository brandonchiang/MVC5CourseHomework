using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework.Models;
using DynamicLINQ;

namespace Homework.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private 客戶Entities db = new 客戶Entities();

        // GET: 客戶資料
        public ActionResult Index()
        {
            if(TempData["query_action"]!=null)
            { 
                var data = (List<客戶資料>) TempData["query_result"];
                if (data == null || data.Count()==0)
                {
                    TempData["query_message"] = "查無資料，請修改查詢條件";
                    return RedirectToAction("Query");
                }
                else
                {
                    //客戶資料 result =(客戶資料) data ; //發現這一動是多餘的，還會出錯
                    return View(data);
                }
            }
            else
                return View(db.客戶資料.ToList());
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Query([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            //客戶資料 客戶資料= new 客戶資料();
            //if (ModelState.IsValid)
            {
                var query = from p in db.客戶資料 select p;

                if (!string.IsNullOrEmpty(客戶資料.客戶名稱)) query = query.Where(x=>x.客戶名稱.Contains(客戶資料.客戶名稱));
                if (!string.IsNullOrEmpty(客戶資料.統一編號)) query = query.Where(x=>x.統一編號.Contains(客戶資料.統一編號));
                if (!string.IsNullOrEmpty(客戶資料.電話)) query = query.Where(x=>x.電話.Contains(客戶資料.電話));
                if (!string.IsNullOrEmpty(客戶資料.傳真)) query = query.Where(x=>x.傳真.Contains(客戶資料.傳真));
                if (!string.IsNullOrEmpty(客戶資料.地址)) query = query.Where(x=>x.地址.Contains(客戶資料.地址));
                if (!string.IsNullOrEmpty(客戶資料.Email)) query = query.Where(x=>x.Email.Contains(客戶資料.Email));

                //return View(result);
                TempData["query_result"] = query.ToList();
                TempData["query_action"] = true;
                return RedirectToAction("Index");
            }
            //return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            db.客戶資料.Remove(客戶資料);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
