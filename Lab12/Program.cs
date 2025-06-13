using Lab12.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega el contexto con la cadena de conexión correcta
//builder.Services.AddDbContext<Context>(options =>
//options.UseSqlServer(@"Server=LAPTOP-R79EK4NG\SQLEXPRESS2017;Database=NunezDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"));
// Agrega el contexto con la cadena de conexión correcta
builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

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
