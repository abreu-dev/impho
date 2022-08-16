using Impho.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text;

namespace Impho.Api.Export
{
    public class ProductCsvResult : FileResult
    {
        private readonly IEnumerable<ProductForExportDto> _products;
        private readonly string _delimiter = ";";

        public ProductCsvResult(IEnumerable<ProductForExportDto> products, string fileName) : base("text/csv")
        {
            _products = products;
            FileDownloadName = fileName;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;

            response.Headers.Add("Content-Disposition", new[] { "attachment;filename=" + FileDownloadName });

            using (var streamWriter = new StreamWriter(response.Body))
            {
                var header = new StringBuilder();
                var properties = new List<PropertyInfo>();

                foreach (var property in typeof(ProductForExportDto).GetProperties())
                {
                    if (property != null)
                    {
                        header.Append(property.Name);
                        header.Append(_delimiter);
                        properties.Add(property);
                    }
                }

                await streamWriter.WriteLineAsync(header);

                foreach (var product in _products)
                {
                    var productAsString = new StringBuilder();

                    foreach (var property in properties)
                    {
                        productAsString.Append(property.GetValue(product));
                        productAsString.Append(_delimiter);
                    }

                    await streamWriter.WriteLineAsync(productAsString);
                    await streamWriter.FlushAsync();
                }

                await streamWriter.FlushAsync();
            }
        }
    }
}
