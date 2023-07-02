using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PathDev.Core.Model.Authorization.Jwt;
using PathDev.Core.Model.Authorization;
using PathDev.Core.Model.Base.Mongo;
using PathDev.Core.Model.Interface.Service.Customer;
using PathDev.Core.Model.Interface.Service.Log;
using PathDev.Core.Model.Interface.Service.Order;
using PathDev.Infrastructure.DataAccess.Service.Address;
using PathDev.Infrastructure.DataAccess.Service.Customer;
using PathDev.Infrastructure.DataAccess.Service.Log;
using PathDev.Infrastructure.DataAccess.Service.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PathDev.Core.Model.Interface.Service.Catalog;
using PathDev.Core.Model.Interface.Service.RabbitMQ;
using PathDev.Infrastructure.DataAccess.Service.Catalog;
using PathDev.Infrastructure.DataAccess.Service.EF;
using PathDev.Core.Model.Interface.Service.Redis;
using PathDev.Infrastructure.DataAccess.Service.RabbitMQ;
using PathDev.Infrastructure.DataAccess.Service.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache(); // Add this line to configure in-memory distributed cache
builder.Services.AddSession(); // Add this line to add session services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PathDevSettings>(builder.Configuration.GetSection(nameof(PathDevSettings)));

builder.Services.AddDbContext<PathDevDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IJwtHelper, JwtHelper>();
builder.Services.AddSingleton<IAuthHelper, AuthHelper>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILogDBService, LogDBService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();
builder.Services.AddSingleton(typeof(IRedisService<>), typeof(RedisService<>));

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
#if DEBUG
        ValidIssuer = builder.Configuration["Jwt:LocalIssuer"],
        ValidAudience = builder.Configuration["Jwt:LocalAudience"],
#else                
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
#endif
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession(); // Make sure to call this before UseAuthentication and UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
