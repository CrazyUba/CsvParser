using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParser.Contracts;
using CsvParser;
using System.IO;
using log4net;

namespace CsvParserImp
{
    public class ColumnDataReader : IColumnDataReader
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        List<string> rows;
        int noOfColumns;
        List<string>[] fileColumns;

        public ColumnDataReader()
        {

        }

        public void Read(UColumn[] uColumns, string filenameForReading)
        {
            log.Debug($"---> uColums.Count: <{uColumns?.Length}>, filenameForReading: <{filenameForReading}>");
            if (uColumns == null) throw new ArgumentNullException("uColumns");
            if (string.IsNullOrEmpty(filenameForReading)) throw new ArgumentNullException("filenameForReading", "... is null or empty");
            if (uColumns.Length == 0) throw new ArgumentOutOfRangeException("uColumns.Length", "Missing columns");

            rows = File.ReadAllLines(filenameForReading).ToList();
            if (rows == null) throw new ArgumentNullException("rows");
            if (rows.Count == 0) throw new ArgumentOutOfRangeException("rows.Count", $"No rows found in file <{filenameForReading}>");

            getNumberOfColumns();

            splitRowsIntoColumns();

            assignFileColumsToUColumns(uColumns);

            log.Debug("<---");

        }

        private void assignFileColumsToUColumns(UColumn[] uColumns)
        {
            foreach (UColumn uColumn in uColumns)
            {
                uColumn.Data = fileColumns[uColumn.ColumnIndexForRead[0]];
            }
        }

        private void splitRowsIntoColumns()
        {
            log.Debug("--->");
            fileColumns = new List<string>[this.noOfColumns];

            string[] rowValues = new string[0];

            foreach (string row in rows)
            {
                rowValues = row.Split(';');

                for (int i = 0; i < rowValues.Length; i++)
                {
                    fileColumns[i].Add(rowValues[i]);
                }
            }
            log.Debug($"<--- columns[0].Count: <{fileColumns[0].Count}>");
        }

        private void getNumberOfColumns()
        {
            log.Debug("--->");
            string[] columns = rows[0].Split(';');
            this.noOfColumns = columns.Length;
            log.Debug($"<--- this.noOfColumns: <{this.noOfColumns}>");
        }


    }
}
