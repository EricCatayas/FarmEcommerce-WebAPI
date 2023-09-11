using ContactsManagement.Web.Filters.ExceptionFilters;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmEcommerce.WebUI.Controllers.v1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(ExceptionHandlingFilter))]
    public class ProductCategoriesController : ApiControllerBase
    {
        private readonly IProductCategoriesGetService _productCategoriesGetService;

        public ProductCategoriesController(IProductCategoriesGetService productCategoriesGetService)
        {
            _productCategoriesGetService = productCategoriesGetService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetAll()
        {
            var result = await _productCategoriesGetService.GetAllAsync();
            return Ok(result);
        }
    }
}
