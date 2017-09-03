using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParser;
using CsvParser.Contracts;
using log4net;
using System.IO;
using CsvHelper;

namespace CsvParserImp
{
    public class ColumnDataWriter : IColumnDataWriter
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Write(UColumn[] uColumns, string filenameForWriting)
        {
            log.Debug("--->");
            if (uColumns == null) throw new ArgumentNullException("uColumns");
            if (string.IsNullOrEmpty(filenameForWriting)) throw new ArgumentNullException("filenameForWriting", "... null or empty");

            if (!Directory.Exists(Path.GetDirectoryName(filenameForWriting))) throw new DirectoryNotFoundException();

            uColumns = uColumns.OrderBy(x => x.ColumnIndexForWrite).ToArray();

            using (var streamWriter = new StreamWriter(filenameForWriting))
            {
                using (var csv = new CsvWriter(streamWriter))
                {
                    csv.Configuration.Delimiter = ";";
                    
                    for (int rowIndex = 0; rowIndex < uColumns[0].Data.Count; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < uColumns.Length; columnIndex++)
                        {
                            csv.WriteField(uColumns[columnIndex].Data[rowIndex]);
                        }
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}
