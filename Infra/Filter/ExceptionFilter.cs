using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text.Json;

namespace MiddlewareTest.Infra.Filter
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Type = GetType().Name,
                Status = StatusCodes.Status500InternalServerError,
                Title = "error occurred",
                Detail = "error occurred",
                Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}"
            };
            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            // Exceptinon Filter只在ExceptionHandled=false時觸發
            // 所以處理完Exception要標記true表示已處理
            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }


    }

    public class ExceptionFilter2 : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
