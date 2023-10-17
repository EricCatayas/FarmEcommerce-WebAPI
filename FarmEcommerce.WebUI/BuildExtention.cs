using Serilog;

namespace FarmEcommerce.WebUI
{
    public static class BuildExtention
    {
        public static WebApplication BuildWithSpa(this WebApplicationBuilder builder) 
        {
            var app = builder.Build();
            //app.UseHsts();
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
            });

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
