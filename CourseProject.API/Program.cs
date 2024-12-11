using CourseProject.API.Controllers;
using CourseProject.BLL.Interfaces;
using CourseProject.BLL.Services;
using CourseProject.Core.Constants;
using CourseProject.Core.Options;
using CourseProject.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
        });
});

builder.Services.Configure<DbOptions>(
    builder.Configuration.GetSection(
        OptionsConstants.DbOptionsKey));

builder.Services.AddDbContext<CourseProjectDbContext>((provider, ctx) =>
{
    var options = provider.GetRequiredService<IOptions<DbOptions>>().Value;
    ctx.UseSqlServer(options.ConnectionString);
});

builder.Services.AddScoped<IIndicatorService, IndicatorService>();
builder.Services.AddScoped<IBackgroundImageService, BackgroundImageService>();

var app = builder.Build();

// Add logging providers
builder.Logging.AddConsole();     // Adds console logging
builder.Logging.AddDebug();       // Adds debug logging
builder.Logging.AddEventLog();    // Adds Windows Event Log (optional)

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<IndicatorHub>("/indicator");

app.MapControllers();

app.Run();