using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2.Processing
{
    class TelegramCorrect : Filter
    {
        private Telegram Telegram;
        public void LoadTelegram(Telegram telegram)
        {
            Telegram = telegram;
            CheckType();
            CheckNullableValues();
        }

        private void CheckType()
        {
            if (Telegram.Type < 1 || (Telegram.Type > 5 && Telegram.Type < 101) || Telegram.Type > 103)
            {
                Console.WriteLine(Telegram + " : Telegram Type error");
            }
        }

        private void CheckNullableValues()
        {
            if (Telegram.ID_Coil < 1)
                Console.WriteLine(Telegram + " : ID coil incorrect");

            if (Telegram.ID_Packet < 1 && Telegram.Type > 100 && Telegram.Type < 104)
                Console.WriteLine(Telegram + " : ID packet incorrect");

            if (Telegram.Count_L2 < 1)
                Console.WriteLine(Telegram + " : L2 Count incorrect");

            if (Telegram.Count_PLC < 1)
                Console.WriteLine(Telegram + " : PLC Count incorrect");

            if (Telegram.Position < 1 || Telegram.Position > 3)
                Console.WriteLine(Telegram + " : Position incorrect");
        }

        public void Statistics()
        {
            //
        }
    }
}
