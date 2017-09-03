using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParser;
using CsvParser.Contracts;
using log4net;
using System.IO;

namespace CsvParserImp
{
    public class ColumnDataWriter : IColumnDataWriter
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        UColumn[] uColumns;
        int noOfRows;

        public ColumnDataWriter()
        {
            
        }

        public void Write(UColumn[] uColumns, string filenameForWriting)
        {
            log.Debug("--->");
            if (uColumns == null) throw new ArgumentNullException("uColumns");
            if (string.IsNullOrEmpty(filenameForWriting)) throw new ArgumentNullException("filenameForWriting", "... null or empty");
            this.uColumns = uColumns;

            getNumberOfRowsToWrite();

            for (int i = 0; i < this.noOfRows; i++)
            {
                foreach (UColumn uColumn in uColumns)
                {
                    //File.WriteAllText();
                }
            }
        }

        private void getNumberOfRowsToWrite()
        {
            log.Debug("--->");
            this.noOfRows = this.uColumns[0].Data.Count;
            log.Debug($"<--- this.noOfColumns: <{this.noOfRows}>");
        }
    }
}
