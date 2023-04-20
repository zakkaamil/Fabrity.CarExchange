using Fabrity.CarExchange.DataAccess.Interfaces;
using Fabrity.CarExchange.DataAccess.Repositories;
using Fabrity.CarExchange.Services.Interfaces;
using Fabrity.CarExchange.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICarsRepository, InMemoryCarsRepository>();
builder.Services.AddScoped<ICarsService, CarsService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
