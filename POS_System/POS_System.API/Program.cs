using POS_System.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultConfigurations();
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddDIContainers();

var app = builder.Build();
app.AddDefaultServiceConfigurations();