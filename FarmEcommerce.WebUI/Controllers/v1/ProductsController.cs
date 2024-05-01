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
using FarmEcommerce.WebUI.Filters.Service;
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
        /// Retrieves a product from the database based on the provided Id.
        /// </summary>
        /// <param name="Id">The unique identifier of the product.</param>
        /// <returns>
        /// Returns a <see cref="ProductDTO"/> object representing the product if found; otherwise, throws error"/>.
        /// </returns>
        /// <response code="400">Product with corresponding Id does not exist in the database.</response>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDTO>> Get(int Id)
        {
            var result = await _mediator.Send(new GetProductQuery() { product_Id = Id });

            Log.Information("{ControllerName}.{MethodName} => {@result}",nameof(ProductsController),nameof(Get),result);

            return Ok(result);
        }
        /// <summary>
        /// Retrieves filtered products from the database.
        /// </summary>
        /// <returns>
        /// Returns an <see cref="IEnumerable{ProductDTO}"/> that satisfy the given property values.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetFilteredProducts(string? product_name, int? store_Id, int? category_Id, bool? is_negotiable, int? min_price, int? max_price, string? quantity_Unit)
        {
            var query = new GetFilteredProductsQuery(new ProductsFilterDTO()
            {
                Name = product_name,
                Store_Id = store_Id,
                Category_Id = category_Id,
                Is_Negotiable = is_negotiable,
                Min_Price = min_price,
                Max_Price = max_price,
                Quantity_Unit = quantity_Unit
            });
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Retrieves a paginated list of products from the database.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of products per page.</param>
        /// <returns>
        /// Returns an <see cref="ActionResult{T}"/> containing a <see cref="ProductPagedResponse"/> object
        /// representing the paginated list of products.
        /// </returns>
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
        /// <summary>
        /// Adds product to the database .
        /// </summary>
        /// <param name="product">The product to be added</param>
        /// <param name="Image_Files">An HTTP request file of image content type.</param>
        /// <returns> Returns the product that is added to the database.</returns>
        /// <response code="400">Unable to create product due to validation error.</response>
        /// <response code="401">Client is unauthorized to access resource.</response>
        [AllowAnonymous]
        [HttpPost]
        // [TypeFilter(typeof(ProductAuthorizeFilter))] Temporary
        public async Task<ActionResult<ProductDTO>> Create([FromForm] ProductCreateDTO product, IEnumerable<IFormFile> Image_Files)
        {
            var command = new CreateProductAndUploadImagesCommand(product, Image_Files);

            var result = await _mediator.Send(command);
            return new CreatedResult($"api/v1/{this.ControllerContext.ActionDescriptor.DisplayName}/{nameof(ProductsController.Get)}/{result.Id}", result);
        }
        /// <summary>
        /// Updates product in the database.
        /// </summary>
        /// <remarks>
        /// **DO NOT USE**. This API currently only supports GET requests.
        /// </remarks>
        /// <param name="product">The product with the new values.</param>
        /// <returns>Returns the product that is updated in the database.</returns>
        /// <response code="400">Unable to update product due to validation error.</response>
        /// <response code="401">Client is unauthorized to access resource.</response>
        [HttpPut]
        [TypeFilter(typeof(ServiceUnavailableFilter))]
        [TypeFilter(typeof(ProductAuthorizeFilter))]
        public async Task<IActionResult> Update([FromForm] ProductUpdateDTO product)
        {
            var command = new UpdateProductCommand(product);

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Deletes a product in the database based on the provided Id.
        /// </summary>
        /// <remarks>
        /// **DO NOT USE**. This API currently only supports GET requests.
        /// </remarks>
        /// <param name="Id">The unique identifyer of the product to be deleted.</param>
        /// <response code="200">Product with corresponding Id is deleted in the database.</response>
        /// <response code="401">Client is unauthorized to access resource.</response>
        /// <response code="404">Product with corresponding Id does not exist in the database.</response>
        [HttpDelete]
        [TypeFilter(typeof(ServiceUnavailableFilter))]
        [TypeFilter(typeof(ProductAuthorizeFilter))]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteProductCommand() { product_Id = Id };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
