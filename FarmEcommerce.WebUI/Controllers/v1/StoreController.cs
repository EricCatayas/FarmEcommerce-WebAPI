using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.WebUI.Commands.Stores;
using FarmEcommerce.WebUI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmEcommerce.WebUI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StoreController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ModelValidationFilter]
        public async Task<ActionResult<Result>> RegisterStore(UserStoreCreateDTO userStore, IFormFile? imageFile)
        {
            var command = new UpdateUserStoreCommand(userStore);
            command.ImageFile = imageFile;
            return Ok();
        }
    }
}
