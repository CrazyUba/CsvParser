using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParser.Contracts;
using CsvParser;
using System.IO;
using log4net;
using CsvHelper;

namespace CsvParserImp
{
    public class ColumnDataReader : IColumnDataReader
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Read(UColumn[] uColumns, string filenameForReading, int startReadAtRow)
        {
            log.Debug($"---> uColums.Count (No of columns in configFile): <{uColumns?.Length}>, filenameForReading: <{filenameForReading}>");
            if (uColumns == null) throw new ArgumentNullException("uColumns");
            if (string.IsNullOrEmpty(filenameForReading)) throw new ArgumentNullException("filenameForReading", "... is null or empty");
            if (uColumns.Length == 0) throw new ArgumentOutOfRangeException("uColumns.Length", "Missing columns");

            if (!File.Exists(filenameForReading)) throw new FileNotFoundException();

            using (var streamReader = File.OpenText(filenameForReading)) {
                using (var csv = new CsvReader(streamReader)) {
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.Delimiter = ";";
                    int skippedRows = 0;
                    while (csv.Read())
                    {
                        if (skippedRows < startReadAtRow)
                        {
                            skippedRows++;
                            continue;
                        }

                        foreach (var uColumn in uColumns)
                        {
                            StringBuilder field = new StringBuilder();
                            for (int i = 0; i < uColumn.ColumnIndexForRead.Length; i++)
                            {
                                field.Append(csv.GetField<string>(uColumn.ColumnIndexForRead[i]-1)); 
                            }
                            uColumn.Data.Add(field.ToString());
                        }
                    }
                }
            }
            
            log.Debug("<---");
        }
    }
}
