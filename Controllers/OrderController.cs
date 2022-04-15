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
        [HttpGet]
        public ActionResult Orders()
        {
            List<Orders> orders = db.Orders.ToList();
            return View(orders);
        }
        [HttpPost]
        public ActionResult Orders(Orders orders)
        {
            db.Orders.Add(orders);
            db.SaveChanges();
            return Redirect("/Order/Orders");
        }
        [HttpGet]
        public ActionResult OEdit(int Id)
        {
            Orders orders = db.Orders.Where(o => o.Id == Id).FirstOrDefault();

            return View(orders);

        }
        [HttpPost]
        public ActionResult OEdit(Orders orders)
        {
            Orders dborders = db.Orders.Where(o => o.Id == orders.Id).FirstOrDefault();

            dborders.BuyerId = orders.BuyerId;
            dborders.ProductId = orders.ProductId;
            dborders.OrderStatusId = orders.OrderStatusId;
            dborders.DateTime = orders.DateTime;
            db.SaveChanges();

            return Redirect("/Order/Orders");
        }
        public ActionResult OView(int Id)
        {
            Orders orders = db.Orders.FirstOrDefault(o => o.Id == Id);
            return View(orders);
        }
        public ActionResult ODelete(int Id)
        {
            Orders orders = db.Orders.FirstOrDefault(o => o.Id == Id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return Redirect("/Order/Orders");
        }
        public ActionResult OSDelete(int Id)
        {
            OrderStatus orderStatus = db.OrderStatus.FirstOrDefault(o => o.Id == Id);
            db.OrderStatus.Remove(orderStatus);
            db.SaveChanges();
            return Redirect("/Order/OrderStatus");
        }
        [HttpGet]
        public ActionResult OrderStatus()
        {
            List<OrderStatus> orderStatus = db.OrderStatus.ToList();
            return View(orderStatus);
        }
        [HttpPost]
        public ActionResult OrderStatus(OrderStatus orderStatus)
        {
            db.OrderStatus.Add(orderStatus);
            db.SaveChanges();
            return Redirect("/Order/OrderStatus");
        }
        [HttpGet]
        public ActionResult OSEdit(int Id)
        {
            OrderStatus orderStatus = db.OrderStatus.Where(o => o.Id == Id).FirstOrDefault();

            return View(orderStatus);

        }
        [HttpPost]
        public ActionResult OSEdit(OrderStatus orderStatus)
        {
            OrderStatus dborders = db.OrderStatus.Where(o => o.Id == orderStatus.Id).FirstOrDefault();

            dborders.Name = orderStatus.Name;
            db.SaveChanges();

            return Redirect("/Order/OrderStatus");
        }
        public ActionResult OSView(int Id)
        {
            OrderStatus orderStatus = db.OrderStatus.FirstOrDefault(o => o.Id == Id);
            return View(orderStatus);
        }
        [HttpGet]
        public ActionResult Role()
        {
            List<Role> roles = db.Roles.ToList();
            return View(roles);
        }
        [HttpPost]
        public ActionResult Role(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return Redirect("/Order/Role");
        }
        [HttpGet]
        public ActionResult REdit(int Id)
        {
            Role role = db.Roles.Where(o => o.Id == Id).FirstOrDefault();

            return View(role);

        }
        [HttpPost]
        public ActionResult REdit(Role role)
        {
            Role dborders = db.Roles.Where(o => o.Id == role.Id).FirstOrDefault();

            dborders.Name = role.Name;

            db.SaveChanges();

            return Redirect("/Order/Role");
        }
        public ActionResult RView(int Id)
        {
            Role role = db.Roles.FirstOrDefault(o => o.Id == Id);
            return View(role);
        }
        public ActionResult RDelete(int Id)
        {
            Role role = db.Roles.FirstOrDefault(o => o.Id == Id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return Redirect("/Order/Role");
        }
        [HttpGet]
        public ActionResult User()
        {
            List<User> users = db.Users.ToList();
            return View(users);
        }
        [HttpPost]
        public ActionResult User(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Redirect("/Order/User");
        }
        [HttpGet]
        public ActionResult UEdit(int Id)
        {
            User user = db.Users.Where(o => o.Id == Id).FirstOrDefault();

            return View(user);

        }
        [HttpPost]
        public ActionResult UEdit(User user)
        {
            User dborders = db.Users.Where(o => o.Id == user.Id).FirstOrDefault();

            dborders.Name = user.Name;
            dborders.Email = user.Email;
            dborders.Password = user.Password;
            dborders.RoleId = user.RoleId;
            db.SaveChanges();

            return Redirect("/Order/User");
        }
        public ActionResult UView(int Id)
        {
            User user = db.Users.FirstOrDefault(o => o.Id == Id);
            return View(user);
        }
        public ActionResult UDelete(int Id)
        {
            User user = db.Users.FirstOrDefault(o => o.Id == Id);
            db.Users.Remove(user);
            db.SaveChanges();
            return Redirect("/Order/User");
        }
    }
}