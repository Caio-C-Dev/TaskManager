using System.Net;
using System.Text.Json;

namespace TaskManager.API.Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                await WriteResponse(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                await WriteResponse(context, HttpStatusCode.Conflict, ex.Message);
            }
            catch (ArgumentException ex)
            {
                await WriteResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await WriteResponse(context, HttpStatusCode.InternalServerError, "Erro interno no servidor.");
            }
        }

        private static async Task WriteResponse(HttpContext context, HttpStatusCode status, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var body = JsonSerializer.Serialize(new { error = message });
            await context.Response.WriteAsync(body);
        }
    }
}