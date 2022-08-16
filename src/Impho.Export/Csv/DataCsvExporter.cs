using Impho.Core.Exporter.Csv;
using System.Reflection;
using System.Text;

namespace Impho.Export.Csv
{
    public class DataCsvExporter : IDataCsvExporter
    {
        private static string _delimiter = ";";

        public ICsvExportedFile Export(IEnumerable<object> products, string fileName)
        {
            var type = products.GetType().GetGenericArguments()[0];
            var properties = new List<PropertyInfo>();

            var header = new StringBuilder();
            foreach (var property in type.GetProperties())
            {
                if (property != null)
                {
                    header.Append(property.Name);
                    header.Append(_delimiter);
                    properties.Add(property);
                }
            }

            var body = new StringBuilder();
            foreach (var product in products)
            {
                var productAsString = new StringBuilder();

                foreach (var property in properties)
                {
                    productAsString.Append(property.GetValue(product));
                    productAsString.Append(_delimiter);
                }

                body.AppendLine(productAsString.ToString());
            }

            var content = new StringBuilder()
                .Append(header)
                .AppendLine("")
                .Append(body);

            return new CsvExportedFile(fileName, content.ToString());
        }
    }
}
