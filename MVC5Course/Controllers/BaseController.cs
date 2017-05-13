using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModels;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
       protected FabricsEntities db = new FabricsEntities();
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    //寫這段打錯網址找不到Action的時候，會直接導回首頁
        //    this.RedirectToAction("Index", "Home").ExecuteResult(this.ControllerContext);
        //}
    }
}