using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public virtual User Seller { get; set; }
        public int SellerId { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public int ProductStatusId { get; set; }
    }
}