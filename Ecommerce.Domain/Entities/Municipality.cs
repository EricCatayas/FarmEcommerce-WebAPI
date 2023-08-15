using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Municipality : BaseEntity
    {
        public string Name { get; set; }
        public int Province_Id { get; set; }
    }
}
