using FarmEcommerce.Core.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactsManagement.Web.Filters.ExceptionFilters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionHandlingFilter> _logger;
        public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {

            _logger.LogError("Exception Filter {FilterName}.{MethodName}\n{ExceptionType}\n{ExceptionMessage}", nameof(ExceptionHandlingFilter), nameof(OnException), context.Exception.GetType().ToString(), context.Exception.Message);

            var response = new
            {
                Message = context.Exception.Message,
                Exception = context.Exception.GetType().Name
            };

            if (context.Exception.GetType() == typeof(DataNotFoundException))
            {
                context.Result = new NotFoundObjectResult(response);
            }
            else if (context.Exception.GetType() == typeof(ArgumentException))
            {
                context.Result = new BadRequestObjectResult(response);
            }
            else if (context.Exception.GetType() == typeof(UnathorizedRequestException))
            {
                context.Result = new UnauthorizedObjectResult(response);
            }
            else
            {
                context.Result = new ObjectResult(response) { StatusCode = 500 };
            }           
        }
    }
}
