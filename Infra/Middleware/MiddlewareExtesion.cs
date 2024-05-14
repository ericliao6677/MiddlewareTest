namespace MiddlewareTest.Infra.Middleware
{
    public static class MiddlewareExtesion
    {
        public static void UseMiddlewareTest(this IApplicationBuilder builder)
        {
           builder.UseMiddleware<MiddlewareTest>();
        }

        public static IApplicationBuilder UseMiddlewareTest2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareTest2>();
        }

        public static void UseGlobalExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        }
    }
}
