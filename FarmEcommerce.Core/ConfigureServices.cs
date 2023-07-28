using FarmEcommerce.Core.ServiceContracts.Images;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Services.Images;
using FarmEcommerce.Core.Services.Products;
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

            return services;
        }
    }
}
