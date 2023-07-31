using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Commands.Products;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.WebUI.Commands.Products;
using FarmEcommerce.WebUI.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmEcommerce.WebUI.Controllers.v1
{
    [ApiVersion("1.0")]    
    public class ProductsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// To get a product from a user's store
        /// </summary>
        /// <param name="product_Id">the id of the product</param>
        /// <returns>Product if found, otherwise null</returns>
        [HttpGet]
        public async Task<ActionResult<Result>> GetProduct(int product_Id)
        {
            var result = await _mediator.Send(new GetProductQuery() { product_Id = product_Id });
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? name, int? category_Id, bool? is_negotiable, int? min_price, int? max_price, int? min_rating_value, string? per_qty_type )
        {
            var command = new GetProductsQuery(new ProductsFilterDTO()
            {
                Name = name,
                Category_Id = category_Id,
                Is_Negotiable = is_negotiable,
                Min_Price = min_price,
                Max_Price = max_price,
                Min_Rating_Value = min_rating_value,
                Per_Qty_Type = per_qty_type
            });
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Result>> CreateProduct(ProductCreateDTO product, IFormFile? image_File)
        {
            var command = new CreateProductWithImagesCommand(product);
            command.image_File = image_File;

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO product)
        {
            var command = new UpdateProductCommand(product);

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int product_Id)
        {
            var command = new DeleteProductCommand() { product_Id = product_Id };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
