using AuctionServer.Data;
using AuctionServer.Hubs;
using AuctionServer.Services;
using AuthModels.Configs;
using ExoticAuctionHouseModel.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options
                    .UseSqlServer(connectionString));

builder.Services.AddHostedService<TimeHostedService>();
builder.Services.Configure<ServicesConfig>(options => builder.Configuration.GetSection("Services").Bind(options));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Angular",
        builder =>
        {
            builder.WithOrigins("http://localhost:4201")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); //TODO: https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/signalr/authn-and-authz.md
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Angular");

app.UseAuthorization();

app.MapControllers();

app.MapHub<AuctionHub>("/Auction");

app.Run();
