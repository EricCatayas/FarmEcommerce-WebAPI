using ContactsManagement.Web.Filters.ExceptionFilters;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.WebUI.Commands.Stores;
using FarmEcommerce.WebUI.Filters;
using FarmEcommerce.WebUI.Queries.Stores;
using FarmEcommerce.WebUI.Filters.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmEcommerce.WebUI.Controllers.v1
{
    /// <summary>
    /// Controller responsible for handling store-related operations.
    /// </summary>
    [ApiVersion("1.0")]
    [TypeFilter(typeof(ServiceUnavailableFilter))]
    [TypeFilter(typeof(ExceptionHandlingFilter))]
    public class StoreController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        /// <remarks>
        /// **DO NOT USE**. This Api is currently not available.
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<Result>> Get(int store_Id)
        {
            var command = new GetStoreQuery() {  store_Id = store_Id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <remarks>
        /// **DO NOT USE**. This Api is currently not available.
        /// </remarks>
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