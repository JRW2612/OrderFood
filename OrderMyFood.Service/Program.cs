// Program.cs or Startup.cs
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using OrderMyFood.Repository.DataBase;
using OrderMyFood.Service;
using Serilog;
using Microsoft.AspNetCore.Authentication.Facebook;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor(); // Adds IHttpContextAccessor to DI
builder.Services.RegisterServices();
builder.Services.AddDbContext<OrderFoodDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseLoggerFactory(LoggerFactory.Create(loggingBuilder => loggingBuilder.AddConsole()));
});

//// Configure authentication schemes for Google, Facebook, and Microsoft
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = MicrosoftAccountDefaults.AuthenticationScheme;
//})
//.AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//})
//.AddFacebook(facebookOptions =>
//{
//    facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
//    facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
//})
//.AddMicrosoftAccount(microsoftOptions =>
//{
//    microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
//    microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
//    microsoftOptions.CallbackPath = new PathString("/signin-microsoft");
//    microsoftOptions.Scope.Add("User.Read"); // Optional scopes
//});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // Adds authentication middleware
app.UseAuthorization();  // Adds authorization middleware
app.MapControllers();
app.Run();
