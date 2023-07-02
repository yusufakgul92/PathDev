using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PathDev.Core.Model.Authorization.Jwt;
using PathDev.Core.Model.Authorization;
using PathDev.Core.Model.Base.Extension;
using PathDev.Core.Model.Interface.Service.Customer;
using PathDev.Core.Model.Interface.Service.Mongo;
using PathDev.Core.Model.Interface.Service.MySQL;
using PathDev.Core.Model.Interface.Service.Order;
using PathDev.Infrastructure.DataAccess.Service.Address;
using PathDev.Infrastructure.DataAccess.Service.EF;
using PathDev.Infrastructure.DataAccess.Service.Order;
using PathDev.Infrastructure.DataAccess.Service.Customer;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using PathDev.Core.Model.Base.Mongo;
using PathDev.Core.Model.Interface.Service.Log;
using PathDev.Core.Model.Interface.Service.Redis;
using PathDev.Infrastructure.DataAccess.Service.Log;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PathDevDbContext>(options => options.UseSqlServer(@"Server=EBILGI-YAKGUL\MSSQLSERVER01;Database=PathDev;Trusted_Connection=True;"));
builder.Services.Configure<PathDevSettings>(builder.Configuration.GetSection(nameof(PathDevSettings)));

builder.Services.AddSingleton<IJwtHelper, JwtHelper>();
builder.Services.AddSingleton<IAuthHelper, AuthHelper>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILogDBService, LogDBService>();

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache(); // Add this line to configure in-memory distributed cache
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSession(); // Add this line to enable session state

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};
var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});

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

app.UseSwaggerAuthorized();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
});


app.UseAuthentication();
app.UseAuthorization();

app.UseSession(); // Add this line to enable session state

app.MapControllers();

app.Run();

