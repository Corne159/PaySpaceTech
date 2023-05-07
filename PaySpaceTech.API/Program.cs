using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaySpaceTech.DataLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var mainConnectionString = builder.Configuration.GetConnectionString("MainConnection") ?? throw new InvalidOperationException("Connection string 'MainConnection' not found.");

// Database context MySQL
builder.Services.AddDbContext<PaySpaceDBContext>(options =>
    options.UseMySql(
        mainConnectionString,
        ServerVersion.AutoDetect(mainConnectionString),
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        })
);

//// Database context MSSQL
//builder.Services.AddDbContext<PaySpaceDBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection"))
//);

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
