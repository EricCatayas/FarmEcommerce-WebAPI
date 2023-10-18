
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.Common.DTO
{
    public class DiscountDTO
    {
        public DiscountDTO(Discount discount)
        {
            this.Discount_Id = discount.Id;
            this.Name = discount.Name;
            this.Description = discount.Description;
            this.Discount_Rate = discount.Discount_Rate;
            this.Start_Date = discount.Start_Date;
            this.End_Date = discount.End_Date;
        }
        public int Discount_Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public float Discount_Rate { get; private set; }
        public DateTime Start_Date { get; private set; }
        public DateTime? End_Date { get; private set; }
    }
}
