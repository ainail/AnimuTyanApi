using DataAccess.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace AnimuTyanApi.Middleware;

public static class ErrorHandlingMiddleware
{
    public static void AddErrorHandlingMiddleware(this WebApplication application)
    {
        application.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                // using static System.Net.Mime.MediaTypeNames;
                context.Response.ContentType = Text.Plain;

                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();

                if (exceptionHandlerPathFeature?.Error is NotFoundException nfe)
                {
                    await context.Response.WriteAsync(nfe.Message);
                }

                if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                {
                    await context.Response.WriteAsync(" The file was not found.");
                }

                if (exceptionHandlerPathFeature?.Path == "/")
                {
                    await context.Response.WriteAsync(" Page: Home.");
                }
            });
        });
    }
}