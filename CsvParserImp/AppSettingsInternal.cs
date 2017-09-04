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

        public int SkipNoOfRowsWithText { get; private set; }

        public string FilenameForReading { get; private set; }

        public string FilenameForWriting { get; private set; }

        public UColumn[] UColumns { get; private set; }

        public AppSettingsInternal()
        {
            SkipNoOfRowsWithText = 3;
            FilenameForReading =  @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\input.csv";
            FilenameForWriting =  @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\output.csv";

            UColumns = new UColumn[] {
                new UColumn { ColumnIndexForRead = new int[] {1} , ColumnIndexForWrite = 2},
                new UColumn { ColumnIndexForRead = new int[] {2,3} , ColumnIndexForWrite = 1}
            };
        }



        //public UColumn[] GetColumns(string configFilename)
        //{
        //    log.Debug($"---> configFilename: <{configFilename}>");
        //    UColumn[] uColumns = {
        //        new UColumn { ColumnIndexForRead = new int[] {1} , ColumnIndexForWrite = 2},
        //        new UColumn { ColumnIndexForRead = new int[] {2,3} , ColumnIndexForWrite = 1},
        //    };

        //    log.Debug("<---");
        //    return uColumns;
        //}

        //public int GetSkipNoOfRowsWithText(string configFilename)
        //{
        //    return 3;
        //}

        //public string GetFilenameForReading(string configFilename)
        //{
        //    return @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\input.csv";
        //}

        //public string GetFilenameForWriting(string configFilename)
        //{
        //    return @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\output.csv";
        //}
    }
}
