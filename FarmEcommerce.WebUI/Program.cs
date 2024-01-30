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
 * 
 *     // Business Logic: GetProducts from given Province or Municipality
 *     Write: Functional tests to ensure new Product is properly set in database (i.e Create + Get Product)
 *     Fix: StoreUpdateService to delete prev image_upload, and others
 *     Look for: Potential Aggregates     
 *     
 *     Is MySQL, or PostgreSQL possible?
 *     
 */

var app = builder.BuildWithSpa();


app.Run();
