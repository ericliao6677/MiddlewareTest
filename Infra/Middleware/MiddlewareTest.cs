namespace MiddlewareTest.Infra.Middleware
{
    public class MiddlewareTest
    {
        private readonly RequestDelegate _next;

        public MiddlewareTest(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext context, IMessageWriter svc)
        {
            //context.Response.ContentType = "text/plain";
            svc.Write($"Middleware 1 - request");
            await _next(context);
            svc.Write("Middleware 1 - reponse");
        }



    }
}
