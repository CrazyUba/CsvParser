namespace CsvParser.Contracts
{
    public interface IColumnDataWriter
    {
        void Write(UColumn[] uColumns, string filenameForWriting);
    }
}