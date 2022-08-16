using Impho.Core.Exporter.Csv;
using Impho.Export.Csv;
using Microsoft.Extensions.DependencyInjection;

namespace Impho.Export
{
    public static class ImphoExportBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Exporters(services);
        }

        public static void Exporters(IServiceCollection services)
        {
            services.AddScoped<IDataCsvExporter, DataCsvExporter>();
        }
    }
}
