using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Images : BaseEntity
    {
        public IEnumerable<Image_Upload>? Uploads { get; set; }
    }
}
