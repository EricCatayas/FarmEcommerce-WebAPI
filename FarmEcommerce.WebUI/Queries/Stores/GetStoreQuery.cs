using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Stores;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Stores
{
    public record GetStoreQuery : IRequest<Store>
    {
        public int store_Id { get; set; }
    }

    public class GetStoreQueryHandler : IRequestHandler<GetStoreQuery, Store>
    {
        private readonly IStoreGetService _storeGetService;

        public GetStoreQueryHandler(IStoreGetService storeGetService)
        {
            _storeGetService = storeGetService;
        }
        public async Task<Store> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _storeGetService.GetById(request.store_Id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
