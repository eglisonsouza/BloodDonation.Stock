using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(builder.Configuration.GetSection("Settings").Get<AppSettings>()!)
    .AddRabbitMq()
    .AddServices()
    .AddHostedServices()
    .AddConsulSettings(builder.Configuration);

var app = builder.Build();

app.UseConsul(builder.Configuration);

app.Run();
