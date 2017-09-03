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

                initConsole();

                initApp();

                startApp();

                signalEndOfAppToUser();


            }
            catch (Exception e)
            {
                log.Fatal(e);
            }
        }

        private static void initConsole()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Beep();
            Console.Clear();
        }


        private static void initApp()
        {
            log.Debug("--->");
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance<IAppSettings>(new AppSettingsInternal());
            container.RegisterInstance<IColumnDataReader>(new ColumnDataReader());
            container.RegisterInstance<IColumnDataWriter>(new ColumnDataWriter());

            csvParser = new CsvParserApp(container);
            
            log.Debug("<---");
        }

        private static void startApp()
        {
            log.Debug("--->");
            csvParser.Parse("dummy.txt");
            log.Debug("<---");
        }


        private static void signalEndOfAppToUser()
        {
            Console.Beep();
            Console.Beep();
        }


    }
}
