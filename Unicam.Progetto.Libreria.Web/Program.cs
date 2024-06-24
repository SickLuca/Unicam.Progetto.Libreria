using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Middlewares;
using Unicam.Progetto.Libreria.Application.Models.Validators;
using Unicam.Progetto.Libreria.Application.Services;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// INIZIALIZZO I SERVIZI

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//funziona con una classe di validazione per ogni singolo oggetto che vogliamo validare, specificandoli
builder.Services.AddFluentValidationAutoValidation();
//li prende tutti
builder.Services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
        SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Progetto.Libreria.Application")
        );


//AddScoped, quindi uno per ogni richiesta http, un'istanza di LibroService (ogni volta che all interno di una classe del framework ha bisogno di utilizzare un oggetto di questo tipo, deve essere risolto in questa maniera
builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer("data source=localhost;Initial catalog=Libreria;User Id=progetto;Password=progetto");
});
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<LibroRepository>();
var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE

app.UseMiddleware<MiddlewareExample>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
