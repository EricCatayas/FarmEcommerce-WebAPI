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
 *     Convert MediaStorageServices to Nuget package
 *         Use Nuget Package for Contacts Management
 *     Check: MockProductCreate Service & ImageUpload
 *     Fix: GUID image upload file name
 *     Check: convert DTOs to record type
 *     Try: Extra event handler for ProductCreateCommand
 *     Fix: StoreUpdateService to delete prev image_upload, and others
 *     Look for: Potential Aggregates    
 *     Write: Functional tests to ensure new Product is properly set in database (i.e Create + Get Product)
 *     
 *     
 */

var app = builder.BuildWithSpa();


app.Run();
