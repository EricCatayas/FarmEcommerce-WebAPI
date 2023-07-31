using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Image_Upload> Image_Uploads { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Line> Order_Lines { get; set; }

        // public DbSet<Order_Status> Order_Statuses { get; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipping_Method> Shipping_Methods { get; set; }
        public DbSet<Shopping_Cart> Shopping_Carts { get; set; }
        public DbSet<Shopping_Cart_Item> Shopping_Cart_Items { get; set; }
        public DbSet<User_Address> User_Addresses { get; set; }
        public DbSet<User_Payment_Method> User_Payment_Methods { get; set; }
        public DbSet<User_Review> User_Reviews { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
