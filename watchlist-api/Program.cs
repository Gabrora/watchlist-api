using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using watchlist_api.Controllers;
using watchlist_api.Data;
using watchlist_api.Interfaces;
using watchlist_api.Validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<watchlist_apiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("watchlist_apiContext") ?? throw new InvalidOperationException("Connection string 'watchlist_apiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IWatchListValidator, WatchListModelValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<watchlist_apiContext>();

            DbSeeder.Seed(context);
        }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
