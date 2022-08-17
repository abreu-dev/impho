using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Impho.Import.Readers
{
    public class CsvReader<TReturn, TMap>
        where TMap : ClassMap<TReturn>
    {
        private const string Delimiter = ";";

        public async Task<IEnumerable<TReturn>> Process(byte[] inputData)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = Delimiter
            };

            using var inputStream = new MemoryStream(inputData);
            using var textReader = new StreamReader(inputStream);
            using var csvReader = new CsvReader(textReader, configuration);
            csvReader.Context.RegisterClassMap<TMap>();
            return csvReader.GetRecords<TReturn>().ToList();
        }
    }
}
