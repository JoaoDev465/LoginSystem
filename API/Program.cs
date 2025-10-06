using _5442.Common.ExtensiveAppBuilder;
using _5442.EndPoints;
using _5442.Services;
using Core.Contracts.AuthContract;
using Core.Interfaces;
using Core.UseCases;
using Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services();
var app = builder.Build();
app.MapEndPoint();
app.Run();

public partial class Program {}