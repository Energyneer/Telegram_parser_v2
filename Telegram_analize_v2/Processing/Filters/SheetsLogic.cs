using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2.Processing
{
    class SheetLogic : Filter
    {
        private HashSet<Sheet> sheets;
        private Dictionary<int, Coil> coils;
        private Dictionary<int, Packet> packets;
        private Telegram currentTelegram;

        public SheetLogic()
        {
            sheets = new HashSet<Sheet>();
            coils = new Dictionary<int, Coil>();
            packets = new Dictionary<int, Packet>();
        }

        public void LoadTelegram(Telegram telegram)
        {
            currentTelegram = telegram;
            if (telegram.Type > 100)
            {
                AddSheetsToSet();
            }
            else
            {
                AddCoilEvents();
            }
        }

        public void Statistics()
        {
            foreach (KeyValuePair<int, Coil> pair in coils)
            {
                coils[pair.Key].SheetsLenght = SheetsLenghtCaclulate(pair.Key);
                PrintFormatting.PrintCoilStatistic(pair);
            }
        }

        private void AddSheetsToSet()
        {
            for (int i = 0; i < currentTelegram.Sheets_Numbers.Length; i++)
            {
                AddSheet(currentTelegram.Sheets_Numbers[i], currentTelegram.Sheets_Lenghts[i], currentTelegram.Sheets_Offset[i]);
            }
        }

        private void AddSheet(int number, double lenght, double offset)
        {
            if (number == 0)
                return;

            Sheet sheet = new Sheet(currentTelegram.ID_Coil, currentTelegram.ID_Packet, number, lenght, offset);
            if (sheets.Contains(sheet))
            {
                PrintFormatting.PrintAddSheetError(currentTelegram.ID_Coil, currentTelegram.ID_Packet, number);
            }
            else
            {
                sheets.Add(sheet);
            }
        }

        private void AddCoilEvents()
        {
            if (!coils.ContainsKey(currentTelegram.ID_Coil))
                coils.Add(currentTelegram.ID_Coil, new Coil());

            AddEvent();

            switch (currentTelegram.Type)
            {
                case 2: coils[currentTelegram.ID_Coil].HeadLenght = currentTelegram.Sheets_Lenghts[0];
                    break;
                case 4: coils[currentTelegram.ID_Coil].DecoilLenght = currentTelegram.Sheets_Offset[0];
                    coils[currentTelegram.ID_Coil].TailLenght = currentTelegram.Sheets_Lenghts[0];
                    break;
                case 5: coils[currentTelegram.ID_Coil].DecoilLenght = currentTelegram.Sheets_Offset[0];
                    coils[currentTelegram.ID_Coil].TailLenght = currentTelegram.Sheets_Lenghts[0];
                    break;
            }
        }

        private void AddEvent()
        {
            if (coils[currentTelegram.ID_Coil].events.Contains(currentTelegram.Type))
            {
                //PrintFormatting.PrintAddEventError();
            }
            else
            {
                coils[currentTelegram.ID_Coil].events.Add(currentTelegram.Type);
            }
        }

        private double SheetsLenghtCaclulate(int ID)
        {
            double summ = 0.0;
            foreach (Sheet sheet in sheets)
            {
                if (sheet.Coil_ID == ID)
                    summ += sheet.Lenght;
            }

            summ += coils[ID].HeadLenght;
            summ += coils[ID].TailLenght;
            return summ;
        }
    }
}
