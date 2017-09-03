using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParser;
using CsvParser.Contracts;
using log4net;

namespace CsvParserImp
{
    public class AppSettingsInternal : IAppSettings
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UColumn[] GetColumns(string configFilename)
        {
            log.Debug($"---> configFilename: <{configFilename}>");
            UColumn[] uColumns = {
                new UColumn { ColumnIndexForRead = new int[] {1} , ColumnIndexForWrite = 1, StartReadAtRow = 1 },
                new UColumn { ColumnIndexForRead = new int[] {2} , ColumnIndexForWrite = 3, StartReadAtRow = 1 },
                new UColumn { ColumnIndexForRead = new int[] {3} , ColumnIndexForWrite = 2, StartReadAtRow = 1 }
            };

            log.Debug("<---");
            return uColumns;

        }

        public string GetFilenameForReading(string configFilename)
        {
            return @"D:\Daten\VisualStudio\CsvParser\Daten\input.csv";
        }

        public string GetFilenameForWriting(string configFilename)
        {
            return @"D:\Daten\VisualStudio\CsvParser\Daten\output.csv";
        }
    }
}
