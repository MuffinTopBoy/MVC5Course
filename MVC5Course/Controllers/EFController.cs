using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class EFController : BaseController
    {
        
        // GET: EF
        public ActionResult Index()
        {
            var data = db.Product.Where(x=>x.Is刪除!=true).OrderByDescending(x=>x.ProductId).Take(10);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = db.Product.Find(id);

            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {
            if (ModelState.IsValid)
            {
                var data = db.Product.Find(id);
                if (data != null)
                {
                    data.ProductName = product.ProductName;
                    data.Price = product.Price;
                    data.Active = product.Active;
                    data.Stock = product.Stock;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var data = db.Product.Find(id);


            //foreach (var item in data.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(item);
            //}

            //這一行等於上面四行
            //db.OrderLine.RemoveRange(data.OrderLine);

            if(data!=null)
            {
                data.Is刪除 = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            var data = db.Database.SqlQuery<Product>("SELECT * FROM dbo.Product WHERE ProductId = @p0", id).FirstOrDefault();

            return View(data);
        }
    }
}