using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2
{
    class Telegram : IComparable
    {
        public int Type { get; set; }
        public int ID_Coil { get; set; }
        public int ID_Packet { get; set; }
        public int Position { get; set; }
        public long Count_PLC { get; set; }
        public long Count_L2 { get; set; }
        public DateTime DT_PLC { get; set; }
        public DateTime DT_L2 { get; set; }
        public int[] Sheets_Numbers { get; set; }
        public double[] Sheets_Lenghts { get; set; }
        public double[] Sheets_Offset { get; set; }

        public Telegram()
        {
            Sheets_Numbers = new int[10];
            Sheets_Lenghts = new double[10];
            Sheets_Offset = new double[10];
        }

        public override string ToString()
        {
            return "Type: " + Type + "  ID Coil: " + ID_Coil + "  ID Packet: " + ID_Packet + "  Time: " + DT_L2;
        }

        public int CompareTo(object obj)
        {
            Telegram previous = obj as Telegram;
            if (previous != null)
            {
                return this.Count_L2 < previous.Count_L2 ? -1 : this.Count_L2 > previous.Count_L2 ? 1 : 0;
            }
            else
            {
                throw new Exception("Compareble error: " + this.Type + " " + this.ID_Coil + " " + this.DT_PLC);
            }
        }
    }
}
