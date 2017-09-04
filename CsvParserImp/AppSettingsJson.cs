using CsvParser.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParser;
using log4net;
using Newtonsoft.Json;
using System.IO;
//using JsonNet.PrivateSettersContractResolvers;

namespace CsvParserImp
{
    public class AppSettingsJson : IAppSettings
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [JsonProperty]
        public int SkipNoOfRowsWithText { get; private set; }

        [JsonProperty]
        public string FilenameForReading { get; private set; }

        [JsonProperty]
        public string FilenameForWriting { get; private set; }

        [JsonProperty]
        public UColumn[] UColumns { get; private set; }



        [JsonConstructor]
        private AppSettingsJson()
        {

        }

        public AppSettingsJson(string configFilename)
        {
            string json = File.ReadAllText(configFilename);

            this.FilenameForReading = JsonConvert.DeserializeObject<AppSettingsJson>(json).FilenameForReading;
            this.FilenameForWriting = JsonConvert.DeserializeObject<AppSettingsJson>(json).FilenameForWriting;
            this.SkipNoOfRowsWithText = JsonConvert.DeserializeObject<AppSettingsJson>(json).SkipNoOfRowsWithText;
            this.UColumns = JsonConvert.DeserializeObject<AppSettingsJson>(json).UColumns;
        }

        //public UColumn[] GetColumns(string configFilename)
        //{
        //    log.Debug($"---> configFilename: <{configFilename}>");

        //    log.Debug("<---");
        //    return UColumns;
        //}

        //public int GetSkipNoOfRowsWithText(string configFilename)
        //{
        //    return SkipNoOfRowsWithText;
        //}

        //public string GetFilenameForReading(string configFilename)
        //{
        //    //return @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\input.csv";
        //    return FilenameForReading;
        //}

        //public string GetFilenameForWriting(string configFilename)
        //{
        //    //return @"C:\Devel\VisalStudio\Projects\CsvParser\Daten\output.csv";
        //    return FilenameForWriting;
        //}
    }
}
