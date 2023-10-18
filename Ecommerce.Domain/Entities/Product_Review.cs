
namespace Ecommerce.Domain.Entities
{
    public class Product_Review : BaseEntity
    {
        public int Product_Id { get; set; }
        public Guid User_Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set;}
        public virtual Product Product { get; set; }

    }
}
