using Impho.Application.Contracts;
using Impho.Core.Messaging.Queries;

namespace Impho.Application.Queries.ProductQueries
{
    public class ExportProductsQuery : IQuery<IEnumerable<ProductForExportDto>>
    {
    }
}
