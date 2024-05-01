
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Mock;
using FarmEcommerce.Core.ServiceContracts.Products;
using Newtonsoft.Json;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockImageUploadCreateService : IImageUploadCreateService
    {
        private readonly IDataFilePath _dataFilePath;

        public MockImageUploadCreateService(IDataFilePath dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }
        public Task<ImageUploadDTO> AddAsync(ImageUploadCreateDTO imageUpload)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ImageUploadDTO>> AddRangeAsync(IEnumerable<ImageUploadCreateDTO> imageUploads)
        {
            try
            {

                string filePath = Path.Combine(_dataFilePath.Get(), "products.json");

                string jsonData = File.ReadAllText(filePath);

                List<Product> products = JsonConvert.DeserializeObject<Product[]>(jsonData).ToList();


                var images_Id = imageUploads.Select(x => x.Images_Id).First();
                var product = products.FirstOrDefault(x => x.Images_Id == images_Id);
                products.Remove(product);

                var images = CreateImages(images_Id, imageUploads);
                product.Images = images; 

                products.Add(product);

                jsonData = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);

                return Task.FromResult(images.Uploads.Select(x => x.ToImageUploadDTO()));
            }
            catch
            {
                throw;
            }
        }

        private Images CreateImages(int images_Id, IEnumerable<ImageUploadCreateDTO> imageUploads)
        {
            var images = new Images();
            images.Id = images_Id;

            images.Uploads = imageUploads.Select(x => new Image_Upload() { Images_Id = images_Id, Image_Url = x.Image_Url, Upload_Date = DateTime.Now });

            return images;
        }
    }
}
