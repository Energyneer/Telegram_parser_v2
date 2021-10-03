using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2
{
    class ParseCSV
    {
        private string filePath;
        private int aprNumber;

        public ParseCSV(string filePath, int aprNumber)
        {
            this.filePath = filePath;
            this.aprNumber = aprNumber;
        }

        public void AddTelegrams(SortedSet<Telegram> source)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                if (CheckAPR(reader.ReadLine()))
                {
                    Processing(reader, source);
                }
            }
        }

        private bool CheckAPR(string line) 
        {
            string[] arr = line.Split(',');
            if (arr.Length > 9 && arr[9].IndexOf('-') > 0)
            {
                try
                {
                    return int.Parse(arr[9].Substring(arr[9].IndexOf('-') + 1, 1)) == aprNumber;
                }
                catch { }
            }
            return false;
        }

        private void Processing(StreamReader reader, SortedSet<Telegram> source)
        {
            reader.ReadLine();
            reader.ReadLine();
            int i = 0;
            StringBuilder builder = new StringBuilder();
            while (reader.Peek() >= 0)
            {
                builder.Append(reader.ReadLine());
                if (++i > 2)
                {
                    source.Add(ParseTelegram(builder.ToString()));
                    builder.Clear();
                    i = 0;
                }
            }
        }

        private Telegram ParseTelegram(string text)
        {
            string[] source = text.Split(',');
            CorrectFormat(source);
            Telegram telegram = new Telegram();
            try
            {
                telegram.Type = int.Parse(source[0]);
                telegram.ID_Coil = int.Parse(source[3]);
                telegram.ID_Packet = int.Parse(source[5]);
                telegram.Position = int.Parse(source[7]);
                telegram.Count_PLC = long.Parse(source[10]);
                telegram.Count_L2 = long.Parse(source[11]);

                telegram.DT_PLC = DateTime.ParseExact(source[13], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                telegram.DT_L2 = DateTime.ParseExact(source[16], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                telegram.Sheets_Numbers[0] = int.Parse(source[21]);
                telegram.Sheets_Offset[0] = double.Parse(source[22]);
                telegram.Sheets_Lenghts[0] = double.Parse(source[23]);

                telegram.Sheets_Numbers[1] = int.Parse(source[24]);
                telegram.Sheets_Offset[1] = double.Parse(source[25]);
                telegram.Sheets_Lenghts[1] = double.Parse(source[26]);

                telegram.Sheets_Numbers[2] = int.Parse(source[27]);
                telegram.Sheets_Offset[2] = double.Parse(source[29]);
                telegram.Sheets_Lenghts[2] = double.Parse(source[30]);

                telegram.Sheets_Numbers[3] = int.Parse(source[32]);
                telegram.Sheets_Offset[3] = double.Parse(source[33]);
                telegram.Sheets_Lenghts[3] = double.Parse(source[34]);

                telegram.Sheets_Numbers[4] = int.Parse(source[35]);
                telegram.Sheets_Offset[4] = double.Parse(source[36]);
                telegram.Sheets_Lenghts[4] = double.Parse(source[38]);

                telegram.Sheets_Numbers[5] = int.Parse(source[40]);
                telegram.Sheets_Offset[5] = double.Parse(source[41]);
                telegram.Sheets_Lenghts[5] = double.Parse(source[42]);

                telegram.Sheets_Numbers[6] = int.Parse(source[43]);
                telegram.Sheets_Offset[6] = double.Parse(source[44]);
                telegram.Sheets_Lenghts[6] = double.Parse(source[45]);

                telegram.Sheets_Numbers[7] = int.Parse(source[46]);
                telegram.Sheets_Offset[7] = double.Parse(source[48]);
                telegram.Sheets_Lenghts[7] = double.Parse(source[49]);

                telegram.Sheets_Numbers[8] = int.Parse(source[51]);
                telegram.Sheets_Offset[8] = double.Parse(source[52]);
                telegram.Sheets_Lenghts[8] = double.Parse(source[53]);

                telegram.Sheets_Numbers[9] = int.Parse(source[54]);
                telegram.Sheets_Offset[9] = double.Parse(source[55]);
                telegram.Sheets_Lenghts[9] = double.Parse(source[57]);
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> Error parse: " + e.Message);
            }
            return telegram;
        }

        private void CorrectFormat(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Replace('.', ',');
            }
        }
    }
}
