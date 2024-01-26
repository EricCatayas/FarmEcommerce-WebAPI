using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using FarmEcommerce.WebUI.Common.Services;
using FarmEcommerce.WebUI.Common.Interfaces;
using Serilog;
using MediaStorageServices.Interfaces.v2;
using MediaStorageServices.Services.AzureStorageContainer.v2;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        //SWAGGER
        services.AddApiVersioning(config =>
        {
            config.ApiVersionReader = new UrlSegmentApiVersionReader();
            //Also supports Header and Query string reader
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "FarmEcommerce Web API", Version = "1.0" });
        });
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV"; // swagger/v1/
            options.SubstituteApiVersionInUrl = true;
        });
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            /*cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>)); <-- Learn More*/
        });
        
        //AUTH
        services.AddControllers(options =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        });

        //CORS
        services.AddCors(options => {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                .WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>())
                //.AllowAnyOrigin() //("accept", "content-type")
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyHeader();
            });
        });        

        services.AddMemoryCache();

        //LOGGING
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        //JWT
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // CookieAuthenticationDefaults.AuthenticationScheme;
        })
         .AddJwtBearer(options => {
             options.TokenValidationParameters = new TokenValidationParameters()
             {
                 ValidateAudience = true,
                 ValidAudience = configuration["Jwt:Audience"],
                 ValidateIssuer = true,
                 ValidIssuer = configuration["Jwt:Issuer"],
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
             };
         });

        //Other Services
        services.AddTransient<IUriService>(provider =>
        {
            var accessor = provider.GetRequiredService<IHttpContextAccessor>();
            var request = accessor.HttpContext.Request;
            var absoluteUri = string.Concat($"{request.Scheme}://{request.Host}{request.Path}");
            return new UriService(absoluteUri);
        });

        services.AddTransient<IImageUploaderService>(provider =>
        {
            var config = provider.GetRequiredService<IConfiguration>();
            string storageAccConnectionString = config["StorageAccountConnectionString"].ToString();
            string blobContainerName = config["BlobContainerName"].ToString();
            return new ImageUploaderService(storageAccConnectionString, blobContainerName);
        });
        services.AddTransient<IImageUploadService, CloudImageUploaderService>();

        return services;
    }
}
