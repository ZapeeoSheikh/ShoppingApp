using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class AccountController : Controller
    {
        ShoppingContext db = new ShoppingContext();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.ProductStatuses = db.ProductStatus.ToList();
            ViewBag.Products = db.Products.ToList();
            ViewBag.Sellers = db.Users.Where(x => x.RoleId == 3).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Product()
        {

            //
            // 
            List<Product> products = db.Products.ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult Product(Product products, HttpPostedFileBase file)
        {
            string filename = DateTime.UtcNow.Ticks + ".jpg";
            file.SaveAs(Server.MapPath("~/dbImage/") + filename);
            products.Image = filename;
            db.Products.Add(products);
            db.SaveChanges();
            return Redirect("/Account/Product");
        }
        [HttpGet]
        public ActionResult PEdit(int Id)
        {
            Product product = db.Products.Where(o => o.Id == Id).FirstOrDefault();

            return View(product);

        }
        [HttpPost]
        public ActionResult PEdit(Product product)
        {
            Product dborders = db.Products.Where(o => o.Id == product.Id).FirstOrDefault();

            dborders.Name = product.Name;
            dborders.Description = product.Description;
            dborders.Price = product.Price;
            dborders.Image = product.Image;
            dborders.SellerId = product.SellerId;
            dborders.ProductStatusId = product.ProductStatusId;
            db.SaveChanges();

            return Redirect("/Account/Product");
        }
        public ActionResult PView(int Id)
        {
            Product product = db.Products.FirstOrDefault(o => o.Id == Id);
            return View(product);
        }
        public ActionResult PDelete(int Id)
        {
            Product product = db.Products.FirstOrDefault(o => o.Id == Id);
            db.Products.Remove(product);
            db.SaveChanges();
            return Redirect("/Account/Product");
        }
        public ActionResult PSDelete(int Id)
        {
            ProductStatus productStatus = db.ProductStatus.FirstOrDefault(o => o.Id == Id);
            db.ProductStatus.Remove(productStatus);
            db.SaveChanges();
            return Redirect("/Account/ProductStatus");
        }
        [HttpGet]
        public ActionResult ProductStatus()
        {
            List<ProductStatus> productStatus = db.ProductStatus.ToList();
            return View(productStatus);
        }
        [HttpPost]
        public ActionResult ProductStatus(ProductStatus productStatus)
        {
            db.ProductStatus.Add(productStatus);
            db.SaveChanges();
            return Redirect("/Account/ProductStatus");
        }
        [HttpGet]
        public ActionResult PSEdit(int Id)
        {
            ProductStatus productStatus = db.ProductStatus.Where(o => o.Id == Id).FirstOrDefault();

            return View(productStatus);

        }
        [HttpPost]
        public ActionResult PSEdit(ProductStatus productStatus)
        {
            ProductStatus dborders = db.ProductStatus.Where(o => o.Id == productStatus.Id).FirstOrDefault();

            dborders.Id = productStatus.Id;
            dborders.Name = productStatus.Name;
            db.SaveChanges();

            return Redirect("/Account/ProductStatus");
        }
        public ActionResult PSView(int Id)
        {
            ProductStatus productStatus = db.ProductStatus.FirstOrDefault(o => o.Id == Id);
            return View(productStatus);
        }

        [HttpGet]
        public ActionResult ProductImage()
        {
            List<ProductImage> productimage = db.ProductImages.ToList();
            return View(productimage);
        }
        [HttpPost]
        public ActionResult ProductImage(ProductImage productsImage, HttpPostedFileBase file)
        {
            string filename = DateTime.UtcNow.Ticks + ".jpg";
            file.SaveAs(Server.MapPath("~/dbImage/") + filename);
            productsImage.Image = filename;
            db.ProductImages.Add(productsImage);
            db.SaveChanges();
            return Redirect("/Account/ProductImage");
        }
        [HttpGet]
        public ActionResult PIEdit(int Id)
        {
            ProductImage productImage = db.ProductImages.Where(o => o.Id == Id).FirstOrDefault();

            return View(productImage);

        }
        [HttpPost]
        public ActionResult PIEdit(ProductImage productImage)
        {
            ProductImage dborders = db.ProductImages.Where(o => o.Id == productImage.Id).FirstOrDefault();

            dborders.ProductId = productImage.ProductId;
            dborders.Image = productImage.Image;

            db.SaveChanges();

            return Redirect("/Account/ProductImage");
        }
        public ActionResult PIView(int Id)
        {
            ProductImage productImage = db.ProductImages.FirstOrDefault(o => o.Id == Id);
            return View(productImage);
        }
        public ActionResult PIDelete(int Id)
        {
            ProductImage productImage = db.ProductImages.FirstOrDefault(o => o.Id == Id);
            db.ProductImages.Remove(productImage);
            db.SaveChanges();
            return Redirect("/Account/ProductImage");
        }



    }
}