using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2.Processing
{
    interface Filter
    {
        void LoadTelegram(Telegram telegram);

        void Statistics();
    }
}
