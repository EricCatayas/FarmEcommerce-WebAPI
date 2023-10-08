using FarmEcommerce.Core;
using FarmEcommerce.Infrastructure;
using FarmEcommerce.WebUI;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebUIServices(builder.Configuration);

/*
 * test1, test1@example.com _Test1
 * test2, test2@example.com _Test2
 * TODO
 *     ProductCategories Service Test
 *     
 *     IImageUploadService refactor for image Width and Size
 *     use MediaStorageService for MagSciAspNetDemo
 *     
 *     Logger Implementation
 *     
 *     Result.Failure --> throw new DataNotFoundException(); 
 *     
 *     CQRS Interview Questions
 *     Specification Interview Q's
 */

var app = builder.BuildWithSpa();


app.Run();
