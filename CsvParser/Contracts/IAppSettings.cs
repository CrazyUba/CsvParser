namespace CsvParser.Contracts
{
    public interface IAppSettings
    {
        UColumn[] GetColumns(string configFilename);
        string GetFilenameForReading(string configFilename);
        string GetFilenameForWriting(string configFilename);
    }
}