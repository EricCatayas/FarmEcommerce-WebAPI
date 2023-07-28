using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Infrastructure.Data.Configurations;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
    {
        public DbSet<Address> Addresses { get; }
        public DbSet<City> Cities { get; }
        public DbSet<Discount> Discounts { get; }
        public DbSet<Image_Upload> Image_Uploads { get; }
        public DbSet<Images> Images { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<Order_Line> Order_Lines { get; }
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
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new DiscountConfiguration());
            builder.ApplyConfiguration(new ImagesConfiguration());
            builder.ApplyConfiguration(new ImageUploadConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderLineConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new PaymentMethodConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new RegionConfiguration());
            builder.ApplyConfiguration(new ShippingMethodConfiguration());
            builder.ApplyConfiguration(new ShoppingCartConfiguration());
            builder.ApplyConfiguration(new ShoppingCartItemConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());
            builder.ApplyConfiguration(new UserAddressConfiguration());
            builder.ApplyConfiguration(new UserReviewConfiguration());
        }
    }
}
