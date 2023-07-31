using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Stores;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Stores
{
    public class UpdateUserStoreCommand : UserStoreUpdateDTO, IRequest<Result>
    {
        public IFormFile? ImageFile { get; set; }
        public UpdateUserStoreCommand(UserStoreCreateDTO userStore)
        {
            Name = userStore.Name;
            Description = userStore.Description;
            Established_Date = userStore.Established_Date;
            Address_Id = userStore.Address_Id;
        }
    }
    public class CreateUserStoreHandler : IRequestHandler<UpdateUserStoreCommand, Result>
    {
        private readonly IStoreUpdateService _storeUpdateService;
        private readonly IImageUploadService _imageUploadService;

        public CreateUserStoreHandler(IStoreUpdateService storeUpdateService, IImageUploadService imageUploadService)
        {
            _storeUpdateService = storeUpdateService;
            _imageUploadService = imageUploadService;
        }
        public async Task<Result> Handle(UpdateUserStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _storeUpdateService.UpdateAsync(request);
                //Update AppUser

                //Image Upload
                if (request.ImageFile != null && request.ImageFile.Length > 0 && request.ImageFile.ContentType.StartsWith("image/"))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.ImageFile.CopyToAsync(memoryStream);
                        byte[] fileData = memoryStream.ToArray();
                        await _imageUploadService.UploadAsync(result.Images_Id, fileData);
                    }
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
