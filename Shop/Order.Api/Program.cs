using Order.Infrastracture;
using Order.Application;
using Order.Api;
using Order.Infrastracture.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.InitialiseDatabaseAsync();

}


app.Run();
