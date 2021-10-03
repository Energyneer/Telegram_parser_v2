using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram_analize_v2.Processing;

namespace Telegram_analize_v2
{
    class PrintFormatting
    {
        private const int tableWidth = 101;

        public static void PrintAddEventError(int countL2, int coilID, int eventCode)
        {
            Console.WriteLine(">> Event!! ");
        }

        public static void PrintAddSheetError(int coilID, int packetID, int number)
        {
            Console.WriteLine(">> Sheet already exist! " + number);
        }

        public static void PrintCoilStatistic(KeyValuePair<int, Coil> pair)
        {
            Coil coil = pair.Value;

            PrintLine();
            PrintRow(
                "ID", 
                "Lenght by Lpm", 
                "E sheet + cuts", 
                "Head cut", 
                "Tail cut");
            PrintRow(
                pair.Key.ToString(), 
                String.Format("{0:0.000}", coil.DecoilLenght / 1000.0), 
                String.Format("{0:0.000}", coil.SheetsLenght / 1000.0), 
                String.Format("{0:0.000}", coil.HeadLenght / 1000.0), 
                String.Format("{0:0.000}", coil.TailLenght / 1000.0));
            Console.WriteLine("Lenght discrepancy: " + String.Format("{0:0.000}", (coil.DecoilLenght - coil.SheetsLenght) / 1000.0) + " m. (" +
                String.Format("{0:0.0}", ((coil.DecoilLenght - coil.SheetsLenght) / coil.SheetsLenght * 100.0)) + "%)");

            PrintEventsStats(coil.events);
        }

        private static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        private static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        private static void PrintEventsStats(ICollection<int> events)
        {
            Console.Write("Events correct: ");
            if (CheckCoilEvents(events))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" TRUE ");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" FALSE ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private static bool CheckCoilEvents(ICollection<int> events)
        {
            return events.Contains(1) && events.Contains(5) ? true :
                events.Contains(1) && events.Contains(2) && events.Contains(4) ? true :
                events.Contains(1) && events.Contains(2) && events.Contains(5) ? true : false;
        }
    }
}
