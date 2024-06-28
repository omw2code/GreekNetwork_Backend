
using Microsoft.EntityFrameworkCore;
using Network.Api.Data;
using Network.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NetworkContext>(options => 
    options.UseSqlServer(connString));

//Configuration Request Pipeline
var app = builder.Build();

app.MapGamesEndPoints();

app.Run();
