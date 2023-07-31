using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.ServiceContracts.Stores;
using FarmEcommerce.Core.Services.Image;
using FarmEcommerce.Core.Services.Products;
using FarmEcommerce.Core.Services.Stores;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductCreateService, ProductCreateService>();
            services.AddTransient<IProductGetService, ProductGetService>();
            services.AddTransient<IProductUpdateService, ProductUpdateService>();
            services.AddTransient<IProductDeleteService, ProductDeleteService>();

            services.AddTransient<IImageUploadService, ImageUploadService>();
            services.AddTransient<IStoreUpdateService, UserStoreUpdateService>();

            return services;
        }
    }
}
