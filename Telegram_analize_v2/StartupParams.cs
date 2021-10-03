using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2
{
    class StartupParams
    {
        public string FilesPath { get; set; }
        public int Number { get; set; }

        public StartupParams(string filesPath, int number)
        {
            FilesPath = filesPath;
            Number = number;
        }
    }
}
