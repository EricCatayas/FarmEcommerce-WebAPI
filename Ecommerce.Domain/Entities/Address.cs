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
        public virtual City City { get; set; }
        public int City_Id { get; set; }
        public virtual Region Region { get; set; }
        public int Region_Id { get; set; }

    }
}