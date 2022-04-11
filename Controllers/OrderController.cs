using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order

        public ActionResult Order()
        {
            return View();
        }
        public ActionResult OrderStatus()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }
        public ActionResult User()
        {
            return View();
        }
    }
}