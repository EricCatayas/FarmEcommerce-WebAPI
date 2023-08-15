using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string? Street { get; set; }
        public string Barangay { get; set; }
        public string? Postal_Code { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public virtual Municipality Municipality { get; set; }
        public int Municipality_Id { get; set; }
        public virtual Province Province { get; set; }
        public int Province_Id { get; set; }

    }
}