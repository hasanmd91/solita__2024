using CityBike.WebApi.src.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "CityBike", Version = "v1" });
    });



var dataSourceBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("SolitaDB"));
var dataSource = dataSourceBuilder.Build();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(dataSource));



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
