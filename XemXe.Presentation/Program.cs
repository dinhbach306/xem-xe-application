using Amazon.S3;
using Mapster;
using Microsoft.EntityFrameworkCore;
using XemXe.Application.Mappings;
using XemXe.Application.Services;
using XemXe.Domain.Repositories;
using XemXe.Infrastructure.Data;
using XemXe.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAwsS3Service, AwsS3Service>();

//AWS S3
builder.Services.AddAWSService<IAmazonS3>(builder.Configuration.GetAWSOptions());
    
// Register mapping dto (Mapster)
// MappingConfig.CarMappings();
TypeAdapterConfig.GlobalSettings.Apply(MappingConfig.GetRegister());

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