using AuthModels.Authorization;
using AuthModels.Configs;
using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouse_API.Repositories.Attributes;
using ExoticAuctionHouse_API.Repositories.Auctions;
using ExoticAuctionHouse_API.Repositories.Cars;
using ExoticAuctionHouse_API.Services.Auctions;
using ExoticAuctionHouse_API.Services.Cars;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options
                    .UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<ICarAttributeRepository, CarAttributeRepository>();
builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IAuctionHistoryRepository, AuctionHistoryRepository>();
builder.Services.AddTransient<IAuctionService, AuctionService>();
builder.Services.AddTransient<IAttributeRepository, AttributeRepository>();

#region Authentication
builder.Services.AddTransient<IPermissionAccess, PermissionAccess>();
builder.Services.Configure<TokenConfig>(options => builder.Configuration.GetSection("Token").Bind(options));

var tokenConfigurationSection = builder.Configuration.GetSection("Token");
var tokenConfig = tokenConfigurationSection.Get<TokenConfig>();
var key = Encoding.ASCII.GetBytes(tokenConfig.SecurityKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
