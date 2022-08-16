namespace Impho.Core.Exporter.Csv
{
    public interface ICsvExportedFile
    {
        string Name { get; }
        string Content { get; }
    }
}
