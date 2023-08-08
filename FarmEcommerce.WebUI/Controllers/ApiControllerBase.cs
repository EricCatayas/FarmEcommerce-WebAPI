using Microsoft.AspNetCore.Mvc;

namespace FarmEcommerce.WebUI.Controllers
{
 [Route("api/v{version:apiVersion}/[controller]/[action]")]
 [ApiController]
 public class ApiControllerBase : ControllerBase
 {
 }
}

