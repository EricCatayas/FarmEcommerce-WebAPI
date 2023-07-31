using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class User_Address : BaseEntity
    {
        public Guid User_Id { get; set; }
        public int Address_Id { get; set; }
        public bool Is_Default { get; set; }
    }
}
