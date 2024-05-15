namespace MiddlewareTest.Infra.Middleware
{
    public class MiddlewareTest2
    {
        private readonly RequestDelegate _next;

        public MiddlewareTest2(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext context, IMessageWriter svc)
        {
            //throw new Exception("Middleware 2 Error");
            svc.Write($"Middleware 2 - request");
            await _next(context);
            svc.Write($"Middleware 2 - response");
        }
    }
}
