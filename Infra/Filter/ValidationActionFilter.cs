using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MiddlewareTest.Infra.Filter
{
    public class ValidationActionFilter : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = 0;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parameter = context.ActionArguments.SingleOrDefault();
            if(parameter.Value is null)
            {
                var response = new ProblemDetails
                {
                    Title = "參數驗證失敗",
                    Instance = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                    Status = (int)HttpStatusCode.BadRequest,

                };
                context.Result = new ObjectResult(response)
                {
                    // 401
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
            }
            else
            {
                await next();
            }
        }
    }
}
