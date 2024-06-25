using Unicam.Progetto.Libreria.Application.Middlewares;

namespace Unicam.Progetto.Libreria.Application.Extensions
{
    public static class MiddlewareExtension
    {

        public static WebApplication? AddApplicationMiddleware(this WebApplication? app)
        {
            app.UseMiddleware<MiddlewareExample>();
            return app;
        }

    }
}
