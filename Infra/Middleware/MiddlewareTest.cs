namespace MiddlewareTest.Infra.Middleware
{
    public class MiddlewareTest
    {
        private readonly RequestDelegate _next;

        public MiddlewareTest(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Middleware 1 - request\n");
            await _next(context);
            await context.Response.WriteAsync("Middleware 1 - reponse\n");
        }



    }
}
