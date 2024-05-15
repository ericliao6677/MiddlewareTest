using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MiddlewareTest.Infra.Filter
{
    public static class FilterExtension
    {
        public static void AddFilter(this MvcOptions options)
        {
            //options.Filters.Add(typeof(ValidationActionFilter));
            //options.Filters.Add(typeof(ResourceFilter));
        }
    }
}
