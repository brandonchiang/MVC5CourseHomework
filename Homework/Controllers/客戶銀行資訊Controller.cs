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
    public class 客戶銀行資訊Controller : BaseController
    {
        //private 客戶Entities db = new 客戶Entities();

        // GET: 客戶銀行資訊
        public ActionResult Index(string sortOrder)
        {
            //db.Configuration.LazyLoadingEnabled = false;
            var where =(客戶銀行資訊)TempData["客戶銀行資訊query_where"] ;

            ViewBag.銀行名稱SortParam = sortOrder == "銀行名稱" ? "銀行名稱desc" : "銀行名稱";
            ViewBag.銀行代碼SortParam = sortOrder == "銀行代碼" ? "銀行代碼desc" : "銀行代碼";
            ViewBag.分行代碼SortParam = sortOrder == "分行代碼" ? "分行代碼desc" : "分行代碼";
            ViewBag.帳戶名稱SortParam = sortOrder == "帳戶名稱" ? "帳戶名稱desc" : "帳戶名稱";
            ViewBag.帳戶號碼SortParam = sortOrder == "帳戶號碼" ? "帳戶號碼desc" : "帳戶號碼";
            ViewBag.客戶名稱SortParam = sortOrder == "客戶名稱" ? "客戶名稱desc" : "客戶名稱";

            if (TempData["客戶銀行資訊query_action"] != null)
            {
                var query = repo客戶銀行資訊.All();

                if (where != null)
                {
                    if (where.客戶Id != 0) query = query.Where(x => x.客戶Id.ToString().Contains(where.客戶Id.ToString()));
                    if (!string.IsNullOrEmpty(where.銀行名稱)) query = query.Where(x => x.銀行名稱.Contains(where.銀行名稱));
                    if (where.銀行代碼 != 0) query = query.Where(x => x.銀行代碼.ToString().Contains(where.銀行代碼.ToString()));
                    if (where.分行代碼 != null) query = query.Where(x => x.分行代碼.ToString().Contains(where.分行代碼.ToString()));
                    if (!string.IsNullOrEmpty(where.帳戶名稱)) query = query.Where(x => x.帳戶名稱.Contains(where.帳戶名稱));
                    if (!string.IsNullOrEmpty(where.帳戶號碼)) query = query.Where(x => x.帳戶號碼.Contains(where.帳戶號碼));
                }
                //var data = (IQueryable<客戶銀行資訊>)TempData["客戶銀行資訊query_result"];
                switch (sortOrder)
                {
                    case "銀行名稱":
                        query = query.OrderBy(s => s.銀行名稱);
                        break;
                    case "銀行名稱desc":
                        query = query.OrderByDescending(s => s.銀行名稱);
                        break;
                    case "銀行代碼":
                        query = query.OrderBy(s => s.銀行代碼);
                        break;
                    case "銀行代碼desc":
                        query = query.OrderByDescending(s => s.銀行代碼);
                        break;
                    case "分行代碼":
                        query = query.OrderBy(s => s.分行代碼);
                        break;
                    case "分行代碼desc":
                        query = query.OrderByDescending(s => s.分行代碼);
                        break;
                    case "帳戶名稱":
                        query = query.OrderBy(s => s.帳戶名稱);
                        break;
                    case "帳戶名稱desc":
                        query = query.OrderByDescending(s => s.帳戶名稱);
                        break;
                    case "帳戶號碼":
                        query = query.OrderBy(s => s.帳戶號碼);
                        break;
                    case "帳戶號碼desc":
                        query = query.OrderByDescending(s => s.帳戶號碼);
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
                var query = repo客戶銀行資訊.All();

                switch (sortOrder)
                {
                    case "銀行名稱":
                        query = query.OrderBy(s => s.銀行名稱);
                        break;
                    case "銀行名稱desc":
                        query = query.OrderByDescending(s => s.銀行名稱);
                        break;
                    case "銀行代碼":
                        query = query.OrderBy(s => s.銀行代碼);
                        break;
                    case "銀行代碼desc":
                        query = query.OrderByDescending(s => s.銀行代碼);
                        break;
                    case "分行代碼":
                        query = query.OrderBy(s => s.分行代碼);
                        break;
                    case "分行代碼desc":
                        query = query.OrderByDescending(s => s.分行代碼);
                        break;
                    case "帳戶名稱":
                        query = query.OrderBy(s => s.帳戶名稱);
                        break;
                    case "帳戶名稱desc":
                        query = query.OrderByDescending(s => s.帳戶名稱);
                        break;
                    case "帳戶號碼":
                        query = query.OrderBy(s => s.帳戶號碼);
                        break;
                    case "帳戶號碼desc":
                        query = query.OrderByDescending(s => s.帳戶號碼);
                        break;
                    case "客戶名稱":
                        query = query.OrderBy(s => s.客戶資料.客戶名稱);
                        break;
                    case "客戶名稱desc":
                        query = query.OrderByDescending(s => s.客戶資料.客戶名稱);
                        break;
                }

                TempData["客戶銀行資訊query_action"] = false;
                return View(query);
            }
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            客戶銀行資訊 客戶銀行資訊 = repo客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱");
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
                repo客戶銀行資訊.Add(客戶銀行資訊);
                repo客戶銀行資訊.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            客戶銀行資訊 客戶銀行資訊 = repo客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
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
                var item = repo客戶銀行資訊.Find(客戶銀行資訊.Id);
                item.客戶Id = 客戶銀行資訊.客戶Id;
                item.銀行名稱 = 客戶銀行資訊.銀行名稱;
                item.銀行代碼 = 客戶銀行資訊.銀行代碼;
                item.分行代碼 = 客戶銀行資訊.分行代碼;
                item.帳戶名稱 = 客戶銀行資訊.帳戶名稱;
                item.帳戶號碼 = 客戶銀行資訊.帳戶號碼;
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
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
                var query = repo客戶銀行資訊.All();

                TempData["客戶銀行資訊query_where"] = 客戶銀行資訊;
                TempData["客戶銀行資訊query_action"] = true;
                return RedirectToAction("Index");
            }
            //return View(客戶資料);
        }

        // GET: 客戶銀行資訊/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = repo客戶銀行資訊.Find(id);
            item.IsDeleted = true;
            repo客戶銀行資訊.UnitOfWork.Commit();
            TempData["客戶銀行資訊Item"] = item;
            TempData["msg"] = "刪除成功";

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
