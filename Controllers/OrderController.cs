using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        ShoppingContext db = new ShoppingContext();
        public ActionResult Order()
        {
            List<Order> order = db.Orders.ToList();
            return View(order);
        }
        public ActionResult OrderStatus()
        {
            List<OrderStatus> orderStatus = db.OrderStatus.ToList();
            return View(orderStatus);
        }
        public ActionResult Role()
        {
            List<Role> roles = db.Roles.ToList();
            return View(roles);
        }
        public ActionResult User()
        {
            List<User> users = db.Users.ToList();
            return View(users);
        }
    }
}