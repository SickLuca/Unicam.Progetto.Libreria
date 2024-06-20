using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Middlewares;
using Unicam.Progetto.Libreria.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// INIZIALIZZO I SERVIZI

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AddScoped, quindi uno per ogni richiesta http, un'istanza di LibroService (ogni volta che all interno di una classe del framework ha bisogno di utilizzare un oggetto di questo tipo, deve essere risolto in questa maniera
builder.Services.AddScoped<ILibroService, LibroService>();

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
