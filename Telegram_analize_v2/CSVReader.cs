using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telegram_analize_v2
{
    class CSVReader
    {
        private StartupParams startupParams;

        public CSVReader(StartupParams startupParams)
        {
            this.startupParams = startupParams;
        }

        public SortedSet<Telegram> ReadData()
        {
            SortedSet<Telegram> telegrams = new SortedSet<Telegram>();
            foreach (string file in GetCSVFilePaths())
            {
                ParseCSV csv = new ParseCSV(file, startupParams.Number);
                csv.AddTelegrams(telegrams);
            }
            return telegrams;
        }

        private List<string> GetCSVFilePaths()
        {
            return new List<string>(Directory.GetFiles(startupParams.FilesPath, "*.csv"));
        }


    }
}
