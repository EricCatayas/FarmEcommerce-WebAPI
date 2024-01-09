
using Bogus;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Infrastructure.Identity;

namespace FarmEcommerce.UnitTests.Core.Products
{
    public abstract class ProductServiceTest
    {
        protected readonly Faker<Address> _addressFaker;
        protected readonly Faker<ApplicationUser> _appUserFaker;
        protected readonly Faker<Images> _imagesFaker;
        protected readonly Faker<Municipality> _municipalityFaker;
        protected readonly Faker<Province> _provinceFaker;
        protected readonly Faker<Product_Category> _productCategoryFaker;
        protected readonly Faker<Product> _productFaker;
        protected readonly Faker<Store> _storeFaker;
        public ProductServiceTest()
        {
            #region ProductFakerInitialization
            _productFaker = new Faker<Product>()
                .RuleFor(x => x.Price, x => x.Finance.Amount(1, int.MaxValue));

            _productCategoryFaker = new Faker<Product_Category>()
                .RuleFor(x => x.Category_Name, x => x.Name.Random.ToString());

            _imagesFaker = new Faker<Images>()
                .RuleFor(x => x.Uploads, null as IEnumerable<Image_Upload>);

            _provinceFaker = new Faker<Province>();
            
            _municipalityFaker = new Faker<Municipality>()
                .RuleFor(x => x.Province, _provinceFaker.Generate());

            _addressFaker = new Faker<Address>()
                .RuleFor(x => x.Municipality, _municipalityFaker.Generate());

            _storeFaker = new Faker<Store>()
                .RuleFor(x => x.Established_Date, x => x.Date.Past())
                .RuleFor(x => x.Description, x => x.Lorem.Sentence());

            _appUserFaker = new Faker<ApplicationUser>()
                .RuleFor(x => x.Contact_Num1, x => x.Phone.ToString())
                .RuleFor(x => x.Contact_Num2, x => x.Phone.ToString());
            #endregion
        }
    }
}
