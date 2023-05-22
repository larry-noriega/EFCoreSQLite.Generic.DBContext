using EFCore_Implementations.Context;
using EFCore_Implementations.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("default");

//Migration DB Purposes
builder.Services.AddDbContext<GenericDBContext<WeatherForecast>>(options => options.UseSqlite(connectionString));

// Set up Database
builder.Services.Configure<SQLiteSettings>(options => { options.ConnectionString = connectionString; });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
