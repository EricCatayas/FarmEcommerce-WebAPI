using ContactsManagement.Web.Filters.ExceptionFilters;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.WebUI.Commands.Stores;
using FarmEcommerce.WebUI.Filters;
using FarmEcommerce.WebUI.Queries.Stores;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmEcommerce.WebUI.Controllers.v1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(ExceptionHandlingFilter))]
    public class StoreController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<Result>> Get(int store_Id)
        {
            var command = new GetStoreQuery() {  store_Id = store_Id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [ModelValidationFilter]
        public async Task<ActionResult<Result>> Update(StoreUpdateDTO userStore, IFormFile? imageFile)
        {
            var command = new UpdateUserStoreCommand(userStore);
            command.ImageFile = imageFile;

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}