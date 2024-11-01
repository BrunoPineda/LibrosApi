using System.Globalization;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar cultura invariable (opcional)
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Obt�n el nombre de la m�quina de forma din�mica
string machineName = Environment.MachineName;
string connectionString = $"Data Source={machineName};Initial Catalog=LibraryDB;Integrated Security=True;";

// Configurar cadena de conexi�n a la base de datos
 
// Registrar el contexto de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configurar CORS para permitir todas las solicitudes (aj�stalo seg�n tus necesidades)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policyBuilder => policyBuilder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
});

// Configurar servicios de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar los repositorios y servicios relacionados con libros
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();

var app = builder.Build();

// Configurar Swagger en modo desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
