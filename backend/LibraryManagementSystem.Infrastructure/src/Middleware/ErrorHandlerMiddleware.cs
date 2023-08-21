using LibraryManagementSystem.Service.src.Shared;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.src.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ExceptionHandler ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(ex.ErrorMessage);
            }
            catch (DbUpdateException ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(ex.InnerException!.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Internal server error. ");
            }
        }
    }
}