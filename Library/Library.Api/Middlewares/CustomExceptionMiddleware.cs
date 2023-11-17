using System.Net;
using System.Text.Json;

namespace Library.Api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var error = new Error
                {
                    StatusCode = context.Response.StatusCode.ToString(),
                    Message = ex.Message,
                };
                
                await context.Response.WriteAsync(error.ToString());
            }
        }
    }

    public class Error
    {
        public string? StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
