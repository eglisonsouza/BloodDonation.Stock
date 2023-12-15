using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Repositories;
using BloodDonation.Stock.Core.Services.Email;
using BloodDonation.Stock.Core.Services.MessageBus;
using BloodDonation.Stock.Infrastructure.Repository;
using BloodDonation.Stock.Infrastructure.Services.Background;
using BloodDonation.Stock.Infrastructure.Services.Email;
using BloodDonation.Stock.Infrastructure.Services.MessageBus.Queues.Publishers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(builder.Configuration.GetSection("Settings").Get<AppSettings>()!);

builder.Services.AddSingleton<IStockRepository, StockRepository>();
builder.Services.AddSingleton<INotificationQueuePublisher, NotificationQueuePublisher>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddHostedService<StockCheckServiceBackgound>();

builder.Build().Run();
