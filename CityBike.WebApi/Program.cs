using CityBike.Core.src.Abstraction;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.Service;
using CityBike.Service.src.Shared;
using CityBike.WebApi.src.Database;
using CityBike.WebApi.src.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Configure lowercase URLs
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CityBike", Version = "v1" });
});
builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});


builder.Services.AddScoped<IStationRepo, StationRepo>();
builder.Services.AddScoped<IJourneyRepo, JourneyRepo>();

builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<IJourneyService, JourneyService>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);


// Configure database context
var connectionString = builder.Configuration.GetConnectionString("SolitaDB");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connectionString));


// Swagger middleware (prioritized for development and all environments)
builder.Services.AddSwaggerGen();
// builder.Services.AddSwaggerUI();

// CORS middleware
builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware pipeline
app.UseSwagger();
app.UseSwaggerUI(c =>
  {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
      c.RoutePrefix = string.Empty;
  }
);
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("_myAllowSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();