using Impho.Core.Exporter.Csv;

namespace Impho.Export.Csv
{
    public class CsvExportedFile : ICsvExportedFile
    {
        public string Name { get; private set; }
        public string Content { get; private set; }

        public CsvExportedFile(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
