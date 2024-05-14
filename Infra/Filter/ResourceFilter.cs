using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddlewareTest.Infra.Filter
{
    public class ResourceFilter : IAsyncResourceFilter
    {
        private static readonly Dictionary<string, ObjectResult> _cache = new Dictionary<string, ObjectResult>();
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var cacheKey = context.HttpContext.Request.Path.ToString();

            if (_cache != null && _cache.ContainsKey(cacheKey))
            {
                var cacheValue = _cache[cacheKey];
                if (cacheValue != null)
                {
                    context.Result = cacheValue;
                }
            }
            else
            {
                var executedContext = await next();

                var result = executedContext.Result as ObjectResult;
                if (result != null)
                {
                    _cache.Add(cacheKey, result);
                }
            }
        }
    }


}
