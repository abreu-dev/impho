namespace Impho.Core.Exporter.Csv
{
    public interface IDataCsvExporter
    {
        ICsvExportedFile Export(IEnumerable<object> products, string fileName);
    }
}
