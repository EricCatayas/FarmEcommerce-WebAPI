using FarmEcommerce.Core;
using FarmEcommerce.Infrastructure;
using FarmEcommerce.WebUI;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebUIServices(builder.Configuration);

builder.Host.UseSerilog();
/*
 * test1, test1@example.com _Test1
 * test2, test2@example.com _Test2
 * TODO
 *     ProductCategories Service Test
 *     
 *     UserAuthTokenService : PRolong expiration date
 *     
 */

var app = builder.BuildWithSpa();


app.Run();
