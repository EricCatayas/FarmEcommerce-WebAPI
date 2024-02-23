using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Infrastructure.Data.Configurations;
using FarmEcommerce.Infrastructure.Data.Seed;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Image_Upload> Image_Uploads { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Line> Order_Lines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Shipping_Method> Shipping_Methods { get; set; }
        public DbSet<Shopping_Cart> Shopping_Carts { get; set; }
        public DbSet<Shopping_Cart_Item> Shopping_Cart_Items { get; set; }
        public DbSet<User_Address> User_Addresses { get; set; }
        public DbSet<User_Payment_Method> User_Payment_Methods { get; set; }
        public DbSet<User_Review> User_Reviews { get; set; }
        public DbSet<Store> Stores { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new DiscountConfiguration());
            builder.ApplyConfiguration(new ImagesConfiguration());
            builder.ApplyConfiguration(new ImageUploadsConfiguration());
            builder.ApplyConfiguration(new MunicipalityConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderLineConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new PaymentMethodConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProvinceConfiguration());
            builder.ApplyConfiguration(new ShippingMethodConfiguration());
            builder.ApplyConfiguration(new ShoppingCartConfiguration());
            builder.ApplyConfiguration(new ShoppingCartItemConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());
            builder.ApplyConfiguration(new UserAddressConfiguration());
            builder.ApplyConfiguration(new UserReviewConfiguration());

            builder.SeedProvinces();
            builder.SeedMunicipalities();
            builder.SeedProductCategories();
        }
    }
}
