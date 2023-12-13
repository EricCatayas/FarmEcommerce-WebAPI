using FarmEcommerce.Core.ServiceContracts.Addresses;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.ServiceContracts.Stores;
using FarmEcommerce.Core.Services.Addresses;
using FarmEcommerce.Core.Services.Image;
using FarmEcommerce.Core.Services.ProductCategories;
using FarmEcommerce.Core.Services.Products;
using FarmEcommerce.Core.Services.Stores;
using MediaStorageServices.Interfaces;
using MediaStorageServices.Services.AzureStorageContainer;
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
            //services.AddTransient<,>();
            services.AddTransient<IAddressCreateService, AddressCreateService>();
            services.AddTransient<IAddressGetService,AddressGetService>();
            services.AddTransient<IAddressUpdateService, AddressUpdateService>();
         
            services.AddTransient<IProductCreateService, ProductCreateService>();
            services.AddTransient<IProductGetService, ProductGetService>();
            services.AddTransient<IProductsGetService, FilteredProductsGetService>();
            services.AddTransient<IProductUpdateService, ProductUpdateService>();
            services.AddTransient<IProductDeleteService, ProductDeleteService>();
            services.AddTransient<IPaginatedProductsGetService, PaginatedProductsGetService>();

            services.AddTransient<IProductCategoriesGetService, ProductCategoriesGetService>();

            services.AddTransient<IProvincesGetService, ProvincesGetService>();
            services.AddTransient<IMunicipalitiesGetService, MunicipalitiesGetService>();

            services.AddTransient<IImageUploadCreateService, ImageUploadCreateService>();            

            services.AddTransient<IStoreGetService, StoreGetService>();
            services.AddTransient<IStoreUpdateService, StoreUpdateService>();

            return services;
        }
    }
}
