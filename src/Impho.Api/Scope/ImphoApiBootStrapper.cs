using Impho.Application;
using Impho.Core;
using Impho.Domain;
using Impho.Export;
using Impho.Infra.Data;

namespace Impho.Api.Scope
{
    public static class ImphoApiBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ImphoCoreBootStrapper.ConfigureServices(services);
            ImphoDomainBootStrapper.ConfigureServices(services);
            ImphoDataBootStrapper.ConfigureServices(services, configuration);
            ImphoApplicationBootStrapper.ConfigureServices(services);
            ImphoExportBootStrapper.ConfigureServices(services);
        }
    }
}
