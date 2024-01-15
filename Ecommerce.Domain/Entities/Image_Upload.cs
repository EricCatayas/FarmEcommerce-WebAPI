using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Image_Upload : BaseEntity
    {
        public virtual Images Images { get; set; }

        public int Images_Id { get; set; }
        public DateTime Upload_Date { get; set; }
        public string Image_Url { get; set; }
    }
}
