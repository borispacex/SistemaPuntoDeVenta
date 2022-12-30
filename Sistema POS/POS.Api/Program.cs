using POS.Application.Extensions;
using POS.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// La conexion con la BD esta en Insfraestructure/Extensions/InjectionExtensions
var configuration = builder.Configuration;
builder.Services.AddInjectionInfraestructure(configuration);
// Injectamos la capa de aplicacion
builder.Services.AddInjectionApplication(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// minusculas URL
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);


var app = builder.Build();

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
