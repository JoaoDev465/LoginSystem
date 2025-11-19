using _5442.Common.ExtensiveApp;
using _5442.Common.ExtensiveAppBuilder;
using _5442.EndPoints;
using _5442.Services;
using Core.Contracts.AuthContract;
using Core.Interfaces;
using Core.UseCases;
using Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services();
builder.AuthSchemaBuilder();
builder.JsonBuilder();
builder.SwachbuckleSwagge();


var app = builder.Build();

var Env = Environments.Development;

if (app.Environment.IsDevelopment())
{
    app.DocApp();
}
app.AuthApp();
app.MapEndPoint();
app.Run();

public partial class Program {}