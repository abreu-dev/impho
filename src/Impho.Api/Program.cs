using Impho.Api.Scope;
using Impho.Api.Scope.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddImphoControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddImphoSwagger();

ImphoApiBootStrapper.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();
app.UseHttpsRedirection();

app.UseImphoSwagger();

app.Run();
