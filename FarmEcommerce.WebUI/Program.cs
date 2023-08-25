using FarmEcommerce.Core;
using FarmEcommerce.Infrastructure;
using FarmEcommerce.WebUI;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebUIServices(builder.Configuration);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();
/*
 * test1, test1@example.com _Test1
 * test2, test2@example.com _Text2
 * TODO
 *     categoriesJson
 *     Result.Failure --> throw new DataNotFoundException(); 
 *     
 *     CQRS Interview Questions
 *     Specification Interview Q's
 */

var app = builder.BuildWithSpa();


app.Run();
