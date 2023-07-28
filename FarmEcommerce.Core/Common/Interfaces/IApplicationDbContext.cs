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
        public DbSet<Address> Addresses { get; }
        public DbSet<City> Cities { get; }
        public DbSet<Discount> Discounts { get; }
        public DbSet<Image_Upload> Image_Uploads { get; }
        public DbSet<Images> Images { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<Order_Line> Order_Lines { get; }

        // public DbSet<Order_Status> Order_Statuses { get; }
        public DbSet<Product> Products { get; }
        public DbSet<Product_Category> Product_Categories { get; }
        public DbSet<Region> Regions { get; }
        public DbSet<Shipping_Method> Shipping_Methods { get; }
        public DbSet<Shopping_Cart> Shopping_Carts { get; }
        public DbSet<Shopping_Cart_Item> Shopping_Cart_Items { get; }
        public DbSet<User_Address> User_Addresses { get; }
        public DbSet<User_Payment_Method> User_Payment_Methods { get; }
        public DbSet<User_Review> User_Reviews { get; }
        public DbSet<Store> Stores { get; }
    }
}
