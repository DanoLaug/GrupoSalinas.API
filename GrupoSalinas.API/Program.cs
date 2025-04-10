using GrupoSalinas.API.Data;
using GrupoSalinas.API.Services.Interfaces;
using GrupoSalinas.API.Services.Implementaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de conexi�n a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de servicios
builder.Services.AddScoped<ICursoService, CursoService>();

// Configuraci�n de Swagger con versi�n OpenAPI 3.0
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GrupoSalinas.API",
        Version = "v1",
        Description = "API para gesti�n de cursos, alumnos y profesores - Prueba T�cnica Grupo Salinas"
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrupoSalinas.API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
