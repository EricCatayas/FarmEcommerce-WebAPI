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

        services.AddCors(options => {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                .WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>())
                //.WithHeaders("accept", "content-type")
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });        

        services.AddMemoryCache();
        return services;
    }
}
