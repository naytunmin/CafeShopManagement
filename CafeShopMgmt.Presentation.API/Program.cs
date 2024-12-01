
using MediatR;

using CafeShopMgmt.Application.UseCases;
using CafeShopMgmt.Infrastructure;

using Swashbuckle.AspNetCore.SwaggerGen;
using CafeShopMgmt.WebApi.Extensions.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add methods Extensions
builder.Services.AddInjectionPersistence(builder);
builder.Services.AddInjectionApplication();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.AddMiddleware();

app.MapControllers();

app.Run();

