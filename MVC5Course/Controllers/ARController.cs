using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {

            return PartialView("Index");
        }

        public ActionResult ContentTest_better()
        {

            return PartialView("JsAlertRedirect", "新增成功!");
        }

        public ActionResult FileTest(string dl)
        {

            if(String.IsNullOrEmpty(dl))
            {
                return File(Server.MapPath("~/App_Data/獵雷艦.jpg"), "image/jpeg");
            }
            else
            {
                return File(Server.MapPath("~/App_Data/獵雷艦.jpg"), "image/jpeg","ship.jpg");
            }
        }

        public ActionResult JsonTest()
        {

            var data = from p in repo.All()
                       select new
                       {
                           p.ProductId,
                           p.ProductName,
                           p.Price
                       };

            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectTest()
        {

            return View();
        }
    }
}