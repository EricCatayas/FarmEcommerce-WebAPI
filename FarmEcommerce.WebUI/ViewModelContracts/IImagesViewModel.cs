using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.WebUI.ViewModelContracts
{
    public interface IImagesViewModel
    {
        List<string>? Image_Urls { get; set; }
    }
}
