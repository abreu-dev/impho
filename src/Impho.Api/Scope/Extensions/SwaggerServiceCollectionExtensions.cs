using Microsoft.OpenApi.Models;

namespace Impho.Api.Scope.Extensions
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AddImphoSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Impho",
                    Description = "Impho Api"
                });
            });
        }

        public static void UseImphoSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
