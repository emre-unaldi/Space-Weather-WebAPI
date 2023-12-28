using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using DataAccess.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In Memory
builder.Services.AddDbContext<SpaceWeatherDbContext>(options => options.UseInMemoryDatabase(databaseName: "SpaceWeatherInMemoryDB"));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Controllers
builder.Services.AddControllers();

// Service Bind
builder.Services.AddScoped<IPlanetService, PlanetManager>();
builder.Services.AddScoped<IPlanetDal, PlanetDal>();

builder.Services.AddScoped<ISatelliteService, SatelliteManager>();
builder.Services.AddScoped<ISatelliteDal, SatelliteDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PlanetDal.Initialize(builder.Services.BuildServiceProvider());
SatelliteDal.Initialize(builder.Services.BuildServiceProvider());

app.MapControllers();

app.Run();
