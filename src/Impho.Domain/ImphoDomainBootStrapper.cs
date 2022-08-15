using Impho.Core.Messaging.Handlers.Interfaces;
using Impho.Domain.Commands.Handlers;
using Impho.Domain.Commands.ProductCommands;
using Microsoft.Extensions.DependencyInjection;

namespace Impho.Domain
{
    public static class ImphoDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommandHandlers(services);
        }

        public static void CommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddProductCommand>, ProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand>, ProductCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveProductCommand>, ProductCommandHandler>();
        }
    }
}
