using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int Region_Id { get; set; }
    }
}
