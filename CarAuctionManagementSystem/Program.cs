
using CarAuctionManagementSystem.Repository;
using CarAuctionManagementSystem.Services;
using CarAuctionManagementSystem.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Repositórios em memória
//builder.Services.AddSingleton<IVehicleRepository, VehicleRepository>();
//builder.Services.AddSingleton<IAuctionRepository, AuctionRepository>();

builder.Services.AddSingleton<IVehicleRepository,VehicleRepository>();
builder.Services.AddSingleton<IAuctionRepository, AuctionRepository>();

// Validator
builder.Services.AddScoped<ICreateVehicleValidator, CreateVehicleValidator>();

// Services
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();

var app = builder.Build();

app.MapControllers();

app.Run();
