using FarmEcommerce.Core;
using FarmEcommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebUIServices(builder.Configuration);

/*
 * test1, test1@example.com _Test1
 * TODO
 *     Address / UserAddress
 *     Add Model Validation Filters, 401 Bad Request -- instead of OK()
 *     
 *     CQRS Interview Questions
 *     Specification Interview Q's
 */

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
});

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
