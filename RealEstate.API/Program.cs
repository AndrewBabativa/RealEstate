using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Application.UseCases.Owner;
using RealEstate.Infrastructure.Storage;
using RealEstate.Infrastructure.Persistence;
using System.Text;
using RealEstate.Application.UseCases.Auth;
using RealEstate.Infrastructure.Services;
using RealEstate.Core.Contracts;
using RealEstate.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using RealEstate.Application.UseCases.Property;
using RealEstate.Application.Validators.Owner;
using RealEstate.Infrastructure.Persistence.Repositories;
using RealEstate.Application.Interfaces.Property;
using RealEstate.Application.Interfaces.Auth;
using RealEstate.Application.Interfaces.Owner;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RealEstateDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            // Log el �xito de la validaci�n del token
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("TokenValidation");
            logger.LogInformation("Token validated successfully for user: {username}", context.Principal?.Identity?.Name);
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            // Log el fallo de la autenticaci�n
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("TokenValidation");
            logger.LogError("Authentication failed: {message}", context.Exception?.Message);
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICreateOwnerHandler, CreateOwnerHandler>();
builder.Services.AddScoped<ILoginHandler, LoginHandler>();
builder.Services.AddScoped<IRegisterHandler, RegisterHandler>();
builder.Services.AddScoped<IChangePriceHandler, ChangePriceHandler>();
builder.Services.AddScoped<IGetPropertyByIdHandler, GetPropertyByIdHandler>();
builder.Services.AddScoped<ICreatePropertyHandler, CreatePropertyHandler>();
builder.Services.AddScoped<IListPropertiesHandler, ListPropertiesHandler>();
builder.Services.AddScoped<IAddImageToPropertyHandler, AddImageToPropertyHandler>();
builder.Services.AddScoped<IUpdatePropertyHandler, UpdatePropertyHandler>();
builder.Services.AddScoped<ICreatePropertyTraceHandler, CreatePropertyTraceHandler>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();
builder.Services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
builder.Services.AddScoped<IDocumentStorageService, CloudinaryService>(provider =>
    new CloudinaryService(
        builder.Configuration["CloudinarySettings:CloudName"],
        builder.Configuration["CloudinarySettings:ApiKey"],
        builder.Configuration["CloudinarySettings:ApiSecret"]
    ));

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug);
});

builder.Services.AddControllers();

// FluentValidation para todos los request
builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<CreateOwnerDtoValidator>();


builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();