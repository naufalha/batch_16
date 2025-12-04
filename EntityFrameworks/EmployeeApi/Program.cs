using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// 2. Configure Entity Framework to use SQLite
// We are defining the connection string directly here for simplicity: "Data Source=app.db"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// 3. Add Swagger/OpenAPI (for testing the API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // This enables the nice UI page to test your API
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
