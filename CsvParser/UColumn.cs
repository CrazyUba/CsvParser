using System.Collections.Generic;

namespace CsvParser
{
    public class UColumn
    {
        public int[] ColumnIndexForRead { get; set; }
        public int ColumnIndexForWrite { get; set; }
        public int StartReadAtRow { get; set; }
        public List<string> Data { get; set; }
    }
}