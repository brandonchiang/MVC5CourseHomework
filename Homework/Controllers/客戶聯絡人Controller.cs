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
    public class 客戶聯絡人Controller : BaseController
    {
        //private 客戶Entities db = new 客戶Entities();

        // GET: 客戶聯絡人
        public ActionResult Index(string 職稱,string sortOrder)
        {
            var where = (客戶聯絡人)TempData["客戶聯絡人query_where"];

            ViewBag.職稱SortParam = sortOrder== "職稱" ? "職稱desc" : "職稱";
            ViewBag.姓名SortParam = sortOrder== "姓名" ? "姓名desc" : "姓名";
            ViewBag.EmailSortParam = sortOrder == "Email" ? "Emaildesc" : "Email";
            ViewBag.手機SortParam = sortOrder == "手機" ? "手機desc" : "手機";
            ViewBag.電話SortParam = sortOrder == "電話" ? "電話desc" : "電話";
            ViewBag.客戶名稱SortParam = sortOrder == "客戶名稱" ? "客戶名稱desc" : "客戶名稱";

            if (TempData["客戶聯絡人query_action"] != null)
            {
                var query = repo客戶聯絡人.All();

                if (where != null)
                {
                    if (where.客戶Id != 0) query = query.Where(x => x.客戶Id.ToString().Contains(where.客戶Id.ToString()));
                    if (!string.IsNullOrEmpty(where.職稱)) query = query.Where(x => x.職稱.Contains(where.職稱));
                    if (!string.IsNullOrEmpty(where.姓名)) query = query.Where(x => x.姓名.ToString().Contains(where.姓名.ToString()));
                    if (!string.IsNullOrEmpty(where.Email)) query = query.Where(x => x.Email.ToString().Contains(where.Email.ToString()));
                }
                //var data = (IQueryable<客戶聯絡人>)TempData["客戶聯絡人query_result"];
                switch (sortOrder)
                {
                    case "職稱":
                        query = query.OrderBy(s => s.職稱);
                        break;
                    case "職稱desc":
                        query = query.OrderByDescending(s => s.職稱);
                        break;
                    case "姓名":
                        query = query.OrderBy(s => s.姓名);
                        break;
                    case "姓名desc":
                        query = query.OrderByDescending(s => s.姓名);
                        break;
                    case "Email":
                        query = query.OrderBy(s => s.Email);
                        break;
                    case "Emaildesc":
                        query = query.OrderByDescending(s => s.Email);
                        break;
                    case "手機":
                        query = query.OrderBy(s => s.手機);
                        break;
                    case "手機desc":
                        query = query.OrderByDescending(s => s.手機);
                        break;
                    case "電話":
                        query = query.OrderBy(s => s.電話);
                        break;
                    case "電話desc":
                        query = query.OrderByDescending(s => s.電話);
                        break;
                    case "客戶名稱":
                        query = query.OrderBy(s => s.客戶資料.客戶名稱);
                        break;
                    case "客戶名稱desc":
                        query = query.OrderByDescending(s => s.客戶資料.客戶名稱);
                        break;
                }
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
                //var 客戶聯絡人 = repo客戶聯絡人.All();
                //return View(客戶聯絡人.ToList());
                var query = repo客戶聯絡人.Empty();
                if (!string.IsNullOrEmpty(職稱))
                    query = repo客戶聯絡人.filterBy職稱(職稱);
                else
                    query = repo客戶聯絡人.All();

                switch (sortOrder)
                {
                    case "職稱":
                        query = query.OrderBy(s => s.職稱);
                        break;
                    case "職稱desc":
                        query = query.OrderByDescending(s => s.職稱);
                        break;
                    case "姓名":
                        query = query.OrderBy(s => s.姓名);
                        break;
                    case "姓名desc":
                        query = query.OrderByDescending(s => s.姓名);
                        break;
                    case "Email":
                        query = query.OrderBy(s => s.Email);
                        break;
                    case "Emaildesc":
                        query = query.OrderByDescending(s => s.Email);
                        break;
                    case "手機":
                        query = query.OrderBy(s => s.手機);
                        break;
                    case "手機desc":
                        query = query.OrderByDescending(s => s.手機);
                        break;
                    case "電話":
                        query = query.OrderBy(s => s.電話);
                        break;
                    case "電話desc":
                        query = query.OrderByDescending(s => s.電話);
                        break;
                    case "客戶名稱":
                        query = query.OrderBy(s => s.客戶資料.客戶名稱);
                        break;
                    case "客戶名稱desc":
                        query = query.OrderByDescending(s => s.客戶資料.客戶名稱);
                        break;
                }

                return View(query);
            }
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱");
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
                repo客戶聯絡人.Add(客戶聯絡人);
                repo客戶聯絡人.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
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
                var item = repo客戶聯絡人.Find(客戶聯絡人.Id);
                item.客戶Id = 客戶聯絡人.客戶Id;
                item.職稱 = 客戶聯絡人.職稱;
                item.姓名 = 客戶聯絡人.姓名;
                item.Email = 客戶聯絡人.Email;
                item.手機 = 客戶聯絡人.手機;
                item.電話 = 客戶聯絡人.電話;
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
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
                var query = repo客戶聯絡人.All();

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
            //客戶資料 客戶資料 = repo客戶資料.Find(id);
            //if (客戶資料 == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(客戶資料);

            var item = repo客戶聯絡人.Find(id);
            item.IsDeleted = true;
            repo客戶聯絡人.UnitOfWork.Commit();
            TempData["客戶聯絡人Item"] = item;
            TempData["msg"] = "刪除成功";

            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    客戶聯絡人 客戶聯絡人 = repo客戶聯絡人.Find(id);
        //    repo客戶聯絡人.Remove(客戶聯絡人);
        //    repoSaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //repoDispose();
            }
            base.Dispose(disposing);
        }
    }
}
