using Microsoft.EntityFrameworkCore;
using Resilia.Academy.Api.Business;
using Resilia.Academy.Api.Business.Interfaces;
using Resilia.Academy.Api.DataAccess;
using Resilia.Academy.Api.DataAccess.Interfaces;
using Resilia.Academy.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApiDb");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add db services to SQL server
builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));

// Inject (create the instances) for the business and the data access layer.
builder.Services.AddScoped<INotificationBusiness, NotificationBusiness>();
builder.Services.AddScoped<INotificationDataAccess, NotificationDataAccess>();

// Add the SignalR service.
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configure the SignalR hubs.
app.MapHub<NotificationsHub>("/notificationshub");

app.Run();
