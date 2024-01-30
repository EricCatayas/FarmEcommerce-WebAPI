using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Stores;
using FarmEcommerce.WebUI.Common.Helpers;
using FarmEcommerce.WebUI.Common.Interfaces;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Stores
{
    public class UpdateUserStoreCommand : StoreUpdateDTO, IRequest<Result>
    {
        public IFormFile? ImageFile { get; set; }
        public UpdateUserStoreCommand(StoreUpdateDTO userStore)
        {
            Id = userStore.Id;
            Name = userStore.Name;
            Description = userStore.Description;
            Established_Date = userStore.Established_Date;
            Address_Id = userStore.Address_Id;
        }
    }
    public class UpdateUserStoreHandler : IRequestHandler<UpdateUserStoreCommand, Result>
    {
        private readonly IStoreUpdateService _storeUpdateService;
        private readonly IImageUploadService _imageUploadService;
        private readonly IImageDeleteService _imageDeleteService;

        public UpdateUserStoreHandler(IStoreUpdateService storeUpdateService, IImageUploadService imageUploadService, IImageDeleteService imageDeleteService)
        {
            _storeUpdateService = storeUpdateService;
            _imageUploadService = imageUploadService;
            _imageDeleteService = imageDeleteService;
        }
        /// <summary>
        /// TODO: Retrieve Images and Delete Prev Image_Upload
        /// </summary>
        public async Task<Result> Handle(UpdateUserStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _storeUpdateService.UpdateAsync(request);
                //Update AppUser

                //Image Upload
                if (request.ImageFile.IsValidImageFile())
                {
                    // TODO
                    await _imageUploadService.UploadAsync(request.ImageFile);                    
                }
                return Result.Success();
            }
            catch(Exception ex)
            {
                return Result.Failure(new List<string> { $"{ex.Message}" });
            }

        }
    }
}
