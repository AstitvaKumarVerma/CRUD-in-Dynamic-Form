using DF_Project_APIs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<sdirectdbContext>(a => a.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;UID=sdirectdb;PWD=sdirectdb;"));
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader();
}));


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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

app.UseCors("corsapp");

app.MapControllers();

app.Run();
