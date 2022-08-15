using Impho.Core.Messaging.Dispatchers;
using Impho.Core.Messaging.Dispatchers.Interfaces;
using Impho.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Impho.Core
{
    public static class ImphoCoreBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Dispatchers(services);
            Notifications(services);
        }

        public static void Dispatchers(IServiceCollection services)
        {
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();
        }

        public static void Notifications(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
        }
    }
}
