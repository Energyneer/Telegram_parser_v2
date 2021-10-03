using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram_analize_v2.Processing;

namespace Telegram_analize_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            StartupParams startupParams = ReadArgs();
            CSVReader csv = new CSVReader(startupParams);

            // all telegrams in all files
            SortedSet<Telegram> telegrams = csv.ReadData();

            // read telegrams
            MainPrc prc = new MainPrc(telegrams);
            prc.Process();
        }

        private static StartupParams ReadArgs()
        {
            return new StartupParams(PathReading(), NumberReading());
        }

        private static string PathReading()
        {
            while (true)
            {
                Console.WriteLine("Write .csv files path:");
                string path = Console.ReadLine();
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Path \"" + path + "\" not exist!");
                    continue;
                }
                return path;
            }
        }

        private static int NumberReading()
        {
            while (true)
            {
                Console.WriteLine("Write Number of APR:");
                string stringNumber = Console.ReadLine();
                int result = 0;
                try
                {
                    result = int.Parse(stringNumber);
                }
                catch
                {
                    Console.WriteLine("\"" + stringNumber + "\" isn't correct number!");
                    continue;
                }
                return result;
            }
        }
    }
}
