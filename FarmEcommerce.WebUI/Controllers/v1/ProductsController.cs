using ContactsManagement.Web.Filters.ExceptionFilters;
using FarmEcommerce.Core.Commands.Products;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.ServiceContracts;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.WebUI.ApiModels;
using FarmEcommerce.WebUI.Commands.Products;
using FarmEcommerce.WebUI.Common.Interfaces;
using FarmEcommerce.WebUI.Filters.ResourceAuthorization;
using FarmEcommerce.WebUI.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace FarmEcommerce.WebUI.Controllers.v1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(ExceptionHandlingFilter))]
    public class ProductsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;

        public ProductsController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }
        /// <summary>
        /// Gets a product from the database
        /// </summary>
        /// <param name="Id">the id of the product</param>
        /// <returns>Product if found, otherwise null</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDTO>> Get(int Id)
        {
            var result = await _mediator.Send(new GetProductQuery() { product_Id = Id });

            Log.Information("{ControllerName}.{MethodName} => {@result}",nameof(ProductsController),nameof(Get),result);

            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetFilteredProducts(string? product_name, int? store_Id, int? category_Id, bool? is_negotiable, int? min_price, int? max_price, string? per_qty_type)
        {
            var query = new GetFilteredProductsQuery(new ProductsFilterDTO()
            {
                Name = product_name,
                Store_Id = store_Id,
                Category_Id = category_Id,
                Is_Negotiable = is_negotiable,
                Min_Price = min_price,
                Max_Price = max_price,
                Per_Qty_Type = per_qty_type
            });
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductPagedResponse>> GetPaginatedProducts(int pageNumber, int pageSize)
        {
            var query = new GetPaginatedProductsQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query);

            var nextPage = _uriService.GetPaginatedUri(new PaginationFilter() { PageNumber = pageNumber + 1, PageSize = pageSize });
            var prevPage = _uriService.GetPaginatedUri(new PaginationFilter() { PageNumber = pageNumber - 1, PageSize = pageSize });
            
            var response = new ProductPagedResponse()
            {
                Data = result,
                NextPage = result.Any() ? nextPage.ToString() : "",
                PreviousPage = prevPage.ToString(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create([FromForm] ProductCreateDTO product, IEnumerable<IFormFile> Image_Files)
        {
            var command = new CreateProductAndUploadImagesCommand(product);
            command.image_Files = Image_Files;

            var result = await _mediator.Send(command);
            return new CreatedResult($"api/v1/{this.ControllerContext.ActionDescriptor.DisplayName}/{nameof(ProductsController.Get)}/{result.Id}", result);
        }
        [HttpPut]
        [TypeFilter(typeof(ProductAuthorizeFilter))]       
        public async Task<IActionResult> Update([FromForm] ProductUpdateDTO product)
        {
            var command = new UpdateProductCommand(product);

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        [TypeFilter(typeof(ProductAuthorizeFilter))]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteProductCommand() { product_Id = Id };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        // Image Related Sh(t
    }
}
