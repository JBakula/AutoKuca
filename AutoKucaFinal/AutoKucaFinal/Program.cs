using AutoKucaFinal.Models;
using AutoKucaFinal.Services.BrandService;
using AutoKucaFinal.Services.BrandServiceRepo;
using AutoKucaFinal.Services.ColorServiceRepo;
using AutoKucaFinal.Services.DoorsServiceRepo;
using AutoKucaFinal.Services.FuelTypeRepo;
using AutoKucaFinal.Services.ModelServiceRepo;
using AutoKucaFinal.Services.TransmissionTypeServiceRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();
builder.Services.AddScoped<IDoorsService, DoorsService>();
builder.Services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();
builder.Services.AddScoped<IColorService, ColorService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<AutoKucaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AutoKucaConnectionString")));
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
