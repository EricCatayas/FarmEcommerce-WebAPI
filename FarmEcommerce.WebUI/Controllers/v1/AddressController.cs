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
    public class AddressController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpPost]
        [TypeFilter(typeof(ExceptionHandlingFilter))]
        public async Task<ActionResult<Result>> Create([FromForm] CreateAddressRequest address)
        {
            var result = await _mediator.Send(address);
            return new CreatedResult($"api/v1/{this.ControllerContext.ActionDescriptor.DisplayName}/{nameof(AddressController.Get)}", result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            var command = new GetUserAddressListQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Municipality>>> Municipalities(int province_Id)
        {
            var result = await _mediator.Send(new GetMunicipalitiesFromProvinceQuery() { Province_Id = province_Id });
            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Province>>> Provinces()
        {
            var result = await _mediator.Send(new GetProvincesQuery() {});
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
