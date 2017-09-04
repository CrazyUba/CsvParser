using CsvParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParserImp
{
    public class ConfigObject
    {
        public int skipNoOfRowsWithText = 3;
        public string filenameForReading = @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\input.csv";
        public string filenameForWriting = @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\output.csv";
        public UColumn[] uColumns = {
                new UColumn { ColumnIndexForRead = new int[] {1} , ColumnIndexForWrite = 2},
                new UColumn { ColumnIndexForRead = new int[] {2,3} , ColumnIndexForWrite = 1},
            };

        public ConfigObject()
        {
            //int skipNoOfRowsWithText = 3;
            //string filenameForReading = @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\input.csv";
            //string filenameForWriting = @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\output.csv";
            //UColumn[] uColumns = {
            //    new UColumn { ColumnIndexForRead = new int[] {1} , ColumnIndexForWrite = 2},
            //    new UColumn { ColumnIndexForRead = new int[] {2,3} , ColumnIndexForWrite = 1},
            //};

        }

    }
}
