using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmEcommerce.WebUI.Filters.Service
{
    /// <summary>
    /// A resource filter that short-circuits the request and returns a status code 503 Service Unavailable response
    /// </summary>
    public class ServiceUnavailableFilter : IResourceFilter
    {

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.Result = new StatusCodeResult(503);            
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }
    }
}
