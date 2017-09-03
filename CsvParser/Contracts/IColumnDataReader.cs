namespace CsvParser.Contracts
{
    public interface IColumnDataReader
    {
        void Read(UColumn[] uColumns, string filenameForReading);
    }
}