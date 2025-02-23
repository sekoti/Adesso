using AdessoDraw.Application.Models.RequestModels;
using AdessoDraw.Domain.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using AdessoDraw.Domain.UOW;
using AdessoDraw.Application.Interfaces;
using AdessoDraw.Application.Services;
using AdessoDraw.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Controller Registration & Fluent Validation
builder.Services.AddDbContext<DrawContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddServices();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<DrawRequestModelValidator>(
    ServiceLifetime.Transient
);

#endregion Controller Registration & Fluent Validation
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



