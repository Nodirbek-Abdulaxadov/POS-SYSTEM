using POS_System.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultConfigurations();
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddDIContainers();

AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();
app.AddDefaultServiceConfigurations();