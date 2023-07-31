using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
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
        services.AddControllers();

        //CORS: localhost:4200, localhost:4100
        services.AddCors(options => {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                .WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>())
                .WithHeaders("Authorization", "origin", "accept", "content-type")
                .WithMethods("GET", "POST", "PUT", "DELETE")
                ;
            });

            options.AddPolicy("4100Client", policyBuilder =>
            {
                policyBuilder
                .WithOrigins(configuration.GetSection("AllowedOrigins2").Get<string[]>())
                .WithHeaders("Authorization", "origin", "accept")
                .WithMethods("GET")
                ;
            });
        });
        return services;
    }
}
