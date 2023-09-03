
using Bogus;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Infrastructure.Identity;

namespace FarmEcommerce.UnitTests.Core.Products
{
    public abstract class ProductServiceTest
    {
        protected readonly Faker<Product_Category> _productCategoryFaker;
        protected readonly Faker<Store> _storeFaker;
        protected readonly Faker<Product> _productFaker;
        protected readonly Faker<Images> _imagesFaker;
        protected readonly Faker<ApplicationUser> _appUserFaker;
        public ProductServiceTest()
        {
            #region ProductFakerInitialization
            _productFaker = new Faker<Product>()
                .RuleFor(x => x.Price, x => x.Finance.Amount(1, int.MaxValue));

            _productCategoryFaker = new Faker<Product_Category>()
                .RuleFor(x => x.Category_Name, x => x.Name.Random.ToString());

            _storeFaker = new Faker<Store>()
                .RuleFor(x => x.Established_Date, DateTime.Now)
                .RuleFor(x => x.Description, x => x.Lorem.Sentence());

            _imagesFaker = new Faker<Images>()
                .RuleFor(x => x.Uploads, null as IEnumerable<Image_Upload>);

            _appUserFaker = new Faker<ApplicationUser>()
                .RuleFor(x => x.Contact_Num1, x => x.Phone.ToString())
                .RuleFor(x => x.Contact_Num2, x => x.Phone.ToString());
            #endregion
        }
    }
}
