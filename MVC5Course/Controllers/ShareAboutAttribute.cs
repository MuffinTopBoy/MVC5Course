using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class ShareAboutAttribute : ActionFilterAttribute
    {
        public string MyProperty { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}