namespace MiddlewareTest.Infra.Middleware
{
    public class MiddlewareTest2
    {
        private readonly RequestDelegate _next;

        public MiddlewareTest2(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Middleware 2 - request\n");
            await _next(context);
            await context.Response.WriteAsync("Middleware 2 - reponse\n");
        }
    }
}
