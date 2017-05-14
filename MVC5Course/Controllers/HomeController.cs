using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Unknow()
        {
            return View("haha");
        }
        [ShareAbout]
        [LocationOnly]
        [HandleError]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }
        [ShareAbout(MyProperty ="haha")]
        public ActionResult PartialAbout()
        {
            //ViewBag.Message = "Your application description page.";

            if(Request.IsAjaxRequest())
            {
                return View();
            }
            else
            {
                return View("About");
            }
            
        }

        public ActionResult SomeAction()
        {
            return PartialView("SuccessRedirect","/");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult GetFile()
        {
            return File("~/Content/12.jpg", "image/jpeg","HAHA.jpg");
        }
        public ActionResult GetJson()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Json(db.Product.Take(10),JsonRequestBehavior.AllowGet);
        }
        public ActionResult VT()
        {
            ViewData.Model = new int[] { 1, 2, 3, 4, 5 };
            return PartialView();
        }
    }
}