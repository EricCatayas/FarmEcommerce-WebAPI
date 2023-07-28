using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string City_Name { get; set; }
        public int Region_Id { get; set; }
    }
}
