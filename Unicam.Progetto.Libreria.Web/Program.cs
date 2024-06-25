using Unicam.Progetto.Libreria.Application.Extensions;
using Unicam.Progetto.Libreria.Application.Middlewares;
using Unicam.Progetto.Libreria.Models.Extensions;
using Unicam.Progetto.Libreria.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// INIZIALIZZO I SERVIZI

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);


var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE
app.AddWebMiddleware()
    .AddApplicationMiddleware();

app.Run();
