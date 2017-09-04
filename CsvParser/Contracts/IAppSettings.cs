namespace CsvParser.Contracts
{
    public interface IAppSettings
    {
        //UColumn[] GetColumns(string configFilename);
        //string GetFilenameForReading(string configFilename);
        //string GetFilenameForWriting(string configFilename);
        //int GetSkipNoOfRowsWithText(string configFilename);

        int SkipNoOfRowsWithText { get; }
       
        string FilenameForReading { get; }
        
        string FilenameForWriting { get; }
        
        UColumn[] UColumns { get; }
    }
}