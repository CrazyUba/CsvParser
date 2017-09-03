using System.Collections.Generic;

namespace CsvParser
{
    public class UColumn
    {
        public int[] ColumnIndexForRead { get; set; }
        public int ColumnIndexForWrite { get; set; }
        public List<string> Data { get; set; }

        public UColumn()
        {
            Data = new List<string>();
        }
    }
}