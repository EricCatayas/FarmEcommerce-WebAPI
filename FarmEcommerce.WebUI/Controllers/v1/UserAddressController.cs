using ContactsManagement.Web.Filters.ExceptionFilters;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.WebUI.ApiModels;
using FarmEcommerce.WebUI.Commands.Addresses;
using FarmEcommerce.WebUI.Filters.ResourceAuthorization;
using FarmEcommerce.WebUI.Queries.Addresses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmEcommerce.WebUI.Controllers.v1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(ExceptionHandlingFilter))]
    public class UserAddressController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public UserAddressController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpPost]
        [TypeFilter(typeof(ExceptionHandlingFilter))]
        public async Task<ActionResult<Result>> Create([FromForm] CreateAddressRequest address)
        {
            var result = await _mediator.Send(address);
            return new CreatedResult($"api/v1/{this.ControllerContext.ActionDescriptor.DisplayName}/{nameof(UserAddressController.Get)}", result);
        }
        [HttpGet]
        //Authorization
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            var command = new GetUserAddressListQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<City>>> GetCities(int? region_Id)
        {
            var result = await _mediator.Send(new GetCitiesFromRegionQuery() { Region_Id = region_Id });
            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            var result = await _mediator.Send(new GetRegionsQuery() {});
            return Ok(result);
        }
        [HttpDelete]
        [TypeFilter(typeof(AddressAuthorizeFilter))]
        public async Task<ActionResult<Result>> Delete(int Id)
        {
            return Ok();
        }
        [HttpPut]
        [TypeFilter(typeof(AddressAuthorizeFilter))]
        public async Task<ActionResult<Result>> Update([FromForm] UpdateAddressRequest address)
        {
            return Ok( await _mediator.Send(address));
        }

    }
}
