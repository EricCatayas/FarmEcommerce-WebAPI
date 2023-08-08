using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Established_Date { get; set; }        
        public int? Address_Id { get; set; }
        public Images Images { get; set; }
        public int Images_Id { get; set; }
        public Guid Owner_Id { get; set; }   
    }
}
