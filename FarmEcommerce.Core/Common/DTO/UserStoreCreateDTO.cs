using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class UserStoreCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public DateTime? Established_Date { get; set; }
        public int? Address_Id { get; set; }
    }
}
