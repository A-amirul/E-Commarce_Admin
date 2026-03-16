using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Ecommerce.CrossCutting.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
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
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Internal server error: {ex.Message}");
            }
        }
    }
}