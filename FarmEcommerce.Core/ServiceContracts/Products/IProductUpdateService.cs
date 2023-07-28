using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductUpdateService
    {
        public Task<Product> UpdateProduct(ProductUpdateDTO product);
    }
}
