﻿using Microsoft.AspNetCore.Diagnostics;
using TicTacToe.Api.Models.Errors;

namespace TicTacToe.Api.Helpers
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            _ => StatusCodes.Status500InternalServerError
                        };
                    }

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        MessageProcessingHandler = contextFeature.Error.Message
                    }).ToString();
                });
            });
        }
    }
}
