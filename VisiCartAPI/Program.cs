using VisiCartAPI.Data;
using VisiCartAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Registro de conexión y repositorios para inyección de dependencias
builder.Services.AddScoped<Connection>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();