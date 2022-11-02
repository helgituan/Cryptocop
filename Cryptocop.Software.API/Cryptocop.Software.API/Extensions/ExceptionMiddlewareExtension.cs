using System.Net;
using Cryptocop.Software.API.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Cryptocop.Software.API.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionHandlerFeature?.Error;
            var statusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is ResourceNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
            }
            else if (exception is EmailAlreadyExistsException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(new ExceptionModel
            {
                StatusCode = statusCode,
                Message = exception?.Message
            }.ToString());
        });
        });
    }
}