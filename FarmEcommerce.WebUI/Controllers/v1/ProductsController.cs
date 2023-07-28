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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(int product_Id)
        {
            var result = await _mediator.Send(new GetProductQuery() { product_Id = product_Id });
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(string? name, int? category_Id, bool? is_negotiable, int? min_price, int? max_price, int? min_rating_value, string? per_qty_type )
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
        public async Task<IActionResult> CreateProduct(ProductCreateDTO product, IFormFile? image_File)
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
