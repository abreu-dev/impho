using Impho.Api.Scope.Filters;

namespace Impho.Api.Scope.Extensions
{
    public static class ControllersServiceCollectionExtensions
    {
        public static void AddImphoControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(NotificationFilter));
            }).AddNewtonsoftJson();
        }
    }
}
