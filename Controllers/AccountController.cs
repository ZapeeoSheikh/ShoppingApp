using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class AccountController : Controller
    {
        ShoppingContext db = new ShoppingContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Product()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult Product(Product products)
        {
            db.Products.Add(products);
            db.SaveChanges();
            return Redirect("/Account/Product");
        }
        public ActionResult PView()
        {
            return View();
        }
        public ActionResult ProductStatus()
        {
            List<ProductStatus> productStatus = db.ProductStatus.ToList();
            return View(productStatus);
        }
        public ActionResult PSView()
        {
            return View();
        }
        public ActionResult ProductImage()
        {
            List<ProductImage> productimage = db.ProductImages.ToList();
            return View(productimage);
        }
        public ActionResult PIView()
        {
            return View();
        }



    }
}