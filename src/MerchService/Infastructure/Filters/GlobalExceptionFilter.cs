using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MerchService.Infastructure.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var resultObject = new
            {
                ExtionType = context.Exception.GetType().FullName,
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace,
                StatusCode = StatusCodes.Status500InternalServerError
            };

            var jsonresult = new JsonResult(resultObject);

            context.Result = jsonresult;
        }
    }
}