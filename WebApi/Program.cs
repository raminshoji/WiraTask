using Application.Common.Interfaces;
using Application.Common.MappingProfiles;
using Application.ExternalServices;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IOpenWeatherApiClient,OpenWeatherApiClient>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<WeatherMappingProfile>();
    cfg.AddProfile<AirQualityMappingProfile>();
});


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
