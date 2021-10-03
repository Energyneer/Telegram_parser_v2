using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2.Processing
{
    class Coil
    {
        public SortedSet<int> events { get; set; }
        public double DecoilLenght { get; set; }
        public double HeadLenght { get; set; }
        public double TailLenght { get; set; }
        public double SheetsLenght { get; set; }

        public Coil()
        {
            events = new SortedSet<int>();
        }
    }
}
