using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.ComponentModel;

namespace Homework.Controllers
{
    public class 客戶資料Controller : BaseController
    {
        //private 客戶Entities db = new 客戶Entities();

        // GET: 客戶資料
        public ActionResult Index(string 客戶分類, string sortOrder)
        {
            //ViewBag.客戶分類 = new SelectList(repo客戶資料.All(), "客戶分類", "客戶分類", null);
            var where = (客戶資料)TempData["客戶資料query_where"];

            ViewBag.客戶名稱SortParam = sortOrder == "客戶名稱" ? "客戶名稱desc" : "客戶名稱";
            ViewBag.統一編號SortParam = sortOrder == "統一編號" ? "統一編號desc" : "統一編號";
            ViewBag.電話SortParam = sortOrder == "電話" ? "電話desc" : "電話";
            ViewBag.傳真SortParam = sortOrder == "傳真" ? "傳真desc" : "傳真";
            ViewBag.地址SortParam = sortOrder == "地址" ? "地址desc" : "地址";
            ViewBag.EmailSortParam = sortOrder == "Email" ? "Emaildesc" : "Email";

            ViewBag.客戶分類 = new SelectList(repo客戶資料.getCalalogList());

            var query = repo客戶資料.All();
            if (TempData["客戶資料query_action"] != null)
            {
                //var data = (List<客戶資料>)TempData["客戶資料query_result"];
                if (where != null)
                {
                    if (where.Id != 0) query = query.Where(x => x.Id.ToString().Contains(where.Id.ToString()));
                    if (!string.IsNullOrEmpty(where.客戶名稱)) query = query.Where(x => x.客戶名稱.Contains(where.客戶名稱));
                    if (!string.IsNullOrEmpty(where.統一編號)) query = query.Where(x => x.統一編號.ToString().Contains(where.統一編號.ToString()));
                    if (where.電話 != null) query = query.Where(x => x.電話.ToString().Contains(where.電話.ToString()));
                    if (!string.IsNullOrEmpty(where.傳真)) query = query.Where(x => x.傳真.Contains(where.傳真));
                    if (!string.IsNullOrEmpty(where.地址)) query = query.Where(x => x.地址.Contains(where.地址));
                    if (!string.IsNullOrEmpty(where.Email)) query = query.Where(x => x.Email.Contains(where.Email));
                }
                if (!string.IsNullOrEmpty(客戶分類))
                    query = query.Where(x => x.客戶分類.Equals(客戶分類));

                query = GetSortParam(sortOrder, query);
                var data = query.ToList();
                if (data == null || data.Count() == 0)
                {
                    TempData["客戶資料query_message"] = "查無資料，請修改查詢條件";
                    return RedirectToAction("Query");
                }
                else
                {
                    //客戶資料 result =(客戶資料) data ; //發現這一動是多餘的，還會出錯
                    //return View(data.Take(100));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(客戶分類))
                    query = repo客戶資料.filterByCatalog(客戶分類);
                else
                    query = repo客戶資料.All();

                query = GetSortParam(sortOrder, query);                
            }

            TempData["客戶資料query_action"] = false;
            return View(query);
        }

        private static IQueryable<客戶資料> GetSortParam(string sortOrder, IQueryable<客戶資料> query)
        {
            switch (sortOrder)
            {
                case "客戶名稱":
                    query = query.OrderBy(s => s.客戶名稱);
                    break;
                case "客戶名稱desc":
                    query = query.OrderByDescending(s => s.客戶名稱);
                    break;
                case "統一編號":
                    query = query.OrderBy(s => s.統一編號);
                    break;
                case "統一編號desc":
                    query = query.OrderByDescending(s => s.統一編號);
                    break;
                case "電話":
                    query = query.OrderBy(s => s.電話);
                    break;
                case "電話desc":
                    query = query.OrderByDescending(s => s.電話);
                    break;
                case "傳真":
                    query = query.OrderBy(s => s.傳真);
                    break;
                case "傳真desc":
                    query = query.OrderByDescending(s => s.傳真);
                    break;
                case "地址":
                    query = query.OrderBy(s => s.地址);
                    break;
                case "地址desc":
                    query = query.OrderByDescending(s => s.地址);
                    break;
                case "Email":
                    query = query.OrderBy(s => s.Email);
                    break;
                case "Emaildesc":
                    query = query.OrderByDescending(s => s.Email);
                    break;
            }

            return query;
        }

        public ActionResult Reload(string catalog)
        {
            var query = repo客戶資料.All();

            if (catalog!="") query = query.Where(x => x.客戶分類.Contains(catalog));

            //return View(result);
            TempData["客戶資料query_result"] = query.ToList();
            TempData["客戶資料query_action"] = true;
            return RedirectToAction("Index");
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            if (客戶資料 == null) 
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        public JsonResult CustInfo(int id)
        {
            客戶資料 cust = repo客戶資料.Find(id);
            if (cust == null) return null;

            var result = new 客戶資料
            {
                Id = cust.Id,
                客戶分類 = cust.客戶分類,
                客戶名稱 = cust.客戶名稱,
                統一編號 = cust.統一編號,
                電話 = cust.電話,
                傳真 = cust.傳真,
                地址 = cust.地址,
                Email = cust.Email
            };
            return Json(result, JsonRequestBehavior.AllowGet);

            //具有潛在危險 Request.Path 的值已從用戶端 (?) 偵測到。
            //return Json(JsonConvert.SerializeObject(cust), JsonRequestBehavior.AllowGet);
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
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                repo客戶資料.Add(客戶資料);
                repo客戶資料.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }


            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            if (客戶資料 == null || 客戶資料.IsDeleted == true)
            {
                //return HttpNotFound();
                TempData["客戶資料error_msg"] = $"id {id} 不存在";
                //return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(客戶資料).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(客戶資料);

            var item = repo客戶資料.Find(客戶資料.Id);
            item.客戶名稱 = 客戶資料.客戶名稱;
            item.客戶聯絡人 = 客戶資料.客戶聯絡人;
            item.客戶銀行資訊 = 客戶資料.客戶銀行資訊;
            item.電話 = 客戶資料.電話;
            item.地址 = 客戶資料.地址;
            item.傳真 = 客戶資料.傳真;
            item.統一編號 = 客戶資料.統一編號;
            item.Email = 客戶資料.Email;
            item.客戶分類 = 客戶資料.客戶分類;

            repo客戶資料.UnitOfWork.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Query([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            //客戶資料 客戶資料= new 客戶資料();
            //if (ModelState.IsValid)
            {
                //var query = repo客戶資料.All();

                //if (!string.IsNullOrEmpty(客戶資料.客戶名稱)) query = query.Where(x=>x.客戶名稱.Contains(客戶資料.客戶名稱));
                //if (!string.IsNullOrEmpty(客戶資料.統一編號)) query = query.Where(x=>x.統一編號.Contains(客戶資料.統一編號));
                //if (!string.IsNullOrEmpty(客戶資料.電話)) query = query.Where(x=>x.電話.Contains(客戶資料.電話));
                //if (!string.IsNullOrEmpty(客戶資料.傳真)) query = query.Where(x=>x.傳真.Contains(客戶資料.傳真));
                //if (!string.IsNullOrEmpty(客戶資料.地址)) query = query.Where(x=>x.地址.Contains(客戶資料.地址));
                //if (!string.IsNullOrEmpty(客戶資料.Email)) query = query.Where(x=>x.Email.Contains(客戶資料.Email));
                //if (!string.IsNullOrEmpty(客戶資料.客戶分類)) query = query.Where(x=>x.客戶分類.Contains(客戶資料.客戶分類));

                //return View(result);
                TempData["客戶資料query_where"] = 客戶資料;
                TempData["客戶資料query_action"] = true;
                return RedirectToAction("Index");
            }
            //return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
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

            var item = repo客戶資料.Find(id);
            item.IsDeleted = true;
            repo客戶資料.UnitOfWork.Commit();
            TempData["客戶資料Item"]= item;
            TempData["msg"] = "刪除成功";

            return RedirectToAction("Index");
        }

        // POST: 客戶資料/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    客戶資料 客戶資料 = db.客戶資料.Find(id);
        //    db.客戶資料.Remove(客戶資料);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public ActionResult Export()
        {
            var data = (from d in repo客戶資料.All()
                       select new
                       {
                           d.Id,
                           d.客戶名稱,
                           d.統一編號,
                           d.電話,
                           d.傳真,
                           d.地址,
                           d.客戶分類
                       }).ToList();
            DataTable dt客戶資料 = ToDataTable(data);
            return base.Export(dt客戶資料, "客戶資料");
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
