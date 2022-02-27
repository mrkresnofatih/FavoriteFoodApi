using System;
using FavoriteFoodApi.Constants;
using FavoriteFoodApi.Constants.CustomExceptions;
using FavoriteFoodApi.Templates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace FavoriteFoodApi.Configurations
{
    public static class AppExceptionHandlerConfig
    {
        public static void UseAppExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var exception = context
                        .Features
                        .Get<IExceptionHandlerPathFeature>()
                        .Error;
                    var errorCode = GetErrorCode(exception);
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsJsonAsync(ResponseHandler.WrapFailure<object>(errorCode));
                });
            });
        }

        private static string GetErrorCode(Exception exception)
        {
            switch (exception)
            {
                case BadRequestException:
                    return ErrorCodes.BAD_REQUEST;
                default:
                    return ErrorCodes.UNHANDLED;
            }
        }
    }
}