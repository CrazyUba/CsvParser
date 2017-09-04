using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using CsvParser;
using CsvParser.Contracts;
using CsvParserImp;

namespace CsvParserConsole
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static CsvParserApp csvParser;

        static void Main(string[] args)
        {
            try
            {
                string configFilename = "config.json";
                if (args.Length == 1) configFilename = args[0].ToString();

                initConsole();

                initApp(configFilename);

                startApp();

                signalEndOfAppToUser();


            }
            catch (Exception e)
            {
                log.Fatal(e);
                Console.ReadKey();
            }
        }

        private static void initConsole()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Beep();
            Console.Clear();
        }


        private static void initApp(string configFilename)
        {
            log.Debug("--->");
            IUnityContainer container = new UnityContainer();
            //container.RegisterInstance<IAppSettings>(new AppSettingsInternal());
            container.RegisterInstance<IAppSettings>(new AppSettingsJson(configFilename));
            container.RegisterInstance<IColumnDataReader>(new ColumnDataReader());
            container.RegisterInstance<IColumnDataWriter>(new ColumnDataWriter());

            csvParser = new CsvParserApp(container);
            
            log.Debug("<---");
        }

        private static void startApp()
        {
            log.Debug("--->");
            csvParser.Parse("configFile.txt");
            log.Debug("<---");
        }


        private static void signalEndOfAppToUser()
        {
            Console.Beep();
            Console.Beep();
            Console.ReadKey();
        }


    }
}
