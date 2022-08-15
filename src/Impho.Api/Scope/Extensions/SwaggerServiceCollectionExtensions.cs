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
                    Title = "Impho"
                });

                var folder = AppContext.BaseDirectory;
                foreach (var file in Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories))
                {
                    options.IncludeXmlComments(filePath: file);
                }

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Imphorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Imphorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
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
