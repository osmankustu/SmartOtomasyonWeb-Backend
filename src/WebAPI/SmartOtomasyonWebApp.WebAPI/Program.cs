using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using SmartOtomasyonWebApp.Application;
using SmartOtomasyonWebApp.Application.Utilities.Security.Encryption;
using SmartOtomasyonWebApp.Application.Utilities.Security.JWT;
using SmartOtomasyonWebApp.Persistance;
using SmartOtomasyonWebApp.Application.DependencyResolvers;
using SmartOtomasyonWebApp.Application.Utilities.IoC;
using SmartOtomasyonWebApp.Extensions;
using SmartOtomasyonWebApp.Persistance.DependencyResolvers;
using Microsoft.EntityFrameworkCore;
using SmartOtomasyonWebApp.Persistance.Context;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new PersistanceModule());
    });

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

// Add services to the container.
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
        new ApplicationModule()
});

builder.Services.AddApplicationRegistiraiton();

builder.Services.AddControllers();
//builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseCors(builder => builder.WithOrigins("http://antalyasmartotomasyon.somee.com").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseCors(builder => builder.WithOrigins("http://antalyasmartotomasyon.com").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseCors(builder => builder.WithOrigins("https://antalyasmartotomasyon.somee.com").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseCors(builder => builder.WithOrigins("https://antalyasmartotomasyon.com").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
