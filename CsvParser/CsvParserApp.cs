using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using CsvParser.Contracts;
using Microsoft.Practices.Unity;


namespace CsvParser
{
    
    public class CsvParserApp
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        IAppSettings appSettings;   
        IColumnDataReader columnDataReader;
        IColumnDataWriter columnDataWriter;
        //UColumn[] uColumns;

        public CsvParserApp(IUnityContainer container)
        {
            log.Debug("--->");
            if (container == null) throw new ArgumentNullException("container");
            this.appSettings = container.Resolve<IAppSettings>();
            this.columnDataReader = container.Resolve<IColumnDataReader>();
            this.columnDataWriter = container.Resolve<IColumnDataWriter>();
            log.Debug("<---");
        }


        public void Parse(string configFilename)
        {
            log.Debug($"---> filename: <{configFilename}>");
            if (string.IsNullOrEmpty(configFilename)) throw new ArgumentNullException("configFile", "... is null or empty");

            // GetColumnConfiguration
            log.Info("Getting configuration for columns ...");
            UColumn[] uColumns = this.appSettings.UColumns;
            string filenameForReading = this.appSettings.FilenameForReading;
            string filenameForWriting = this.appSettings.FilenameForWriting;
            int skipNoOfRowsWithText = this.appSettings.SkipNoOfRowsWithText; 
            log.Info("Getting configuration for columns ... done");
            log.Info($"filenameForReading: <{filenameForReading}>, filenameForWriting: <{filenameForWriting}>, skipNoOfRowsWithText: <{skipNoOfRowsWithText}>");

            // ReadColumnData
            log.Info("Reading column data ...");
            columnDataReader.Read(uColumns, filenameForReading, skipNoOfRowsWithText);
            log.Info("Reading column data ... done");
            log.Info($"No of columns: <{uColumns.Length}>, no of rows: <{uColumns[0].Data.Count}>");

            // WriteColumnData
            log.Info("Writing column data ...");
            columnDataWriter.Write(uColumns, filenameForWriting);
            log.Info("Writing column data ... done");
            log.Debug("<---");

        }
    }
}
