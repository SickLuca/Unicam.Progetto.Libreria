using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Unicam.Progetto.Libreria.Application.Factories;

namespace Unicam.Progetto.Libreria.Web.Extensions
{
    public static class MiddlewareExtension
    {

        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(res);
                    }
                });
            });

            app.MapControllers();
            return app;
        }

    }
}
