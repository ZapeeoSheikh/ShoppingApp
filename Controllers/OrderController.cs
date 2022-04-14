﻿using System;
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
        public ActionResult EOrders(int Id)
        {
            Orders orders = db.Orders.Where(o => o.Id == Id).FirstOrDefault();
            db.SaveChanges();
            return View(orders);
        }
        [HttpPost]
        public ActionResult EOrders(Orders orders)
        {
            Orders dborders = db.Orders.Where(o => o.Id == orders.Id).FirstOrDefault();
            dborders.BuyerId = orders.BuyerId;
            dborders.ProductId = orders.ProductId;
            dborders.OrderStatusId = orders.OrderStatusId;
            dborders.DateTime = orders.DateTime;
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
        public ActionResult OSView(int Id)
        {
            OrderStatus orderStatus = db.OrderStatus.FirstOrDefault(o => o.Id == Id);
            return View(orderStatus);
        }
        public ActionResult OSDelete(int Id)
        {
            OrderStatus orderStatus = db.OrderStatus.FirstOrDefault(o => o.Id == Id);
            db.OrderStatus.Remove(orderStatus);
            db.SaveChanges();
            return Redirect("/Order/OrderStatus");
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