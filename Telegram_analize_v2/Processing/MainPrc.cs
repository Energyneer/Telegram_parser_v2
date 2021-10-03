using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2.Processing
{
    class MainPrc
    {
        private SortedSet<Telegram> telegrams;
        private List<Filter> filters;

        public MainPrc(SortedSet<Telegram> telegrams)
        {
            this.telegrams = telegrams;
            filters = new List<Filter>();
            filters.Add(new TelegramCorrect());
            filters.Add(new SheetLogic());
        }

        public void Process()
        {
            foreach (Telegram telegram in telegrams)
            {
                foreach (Filter filter in filters)
                {
                    filter.LoadTelegram(telegram);
                }
            }

            foreach (Filter filter in filters)
            {
                filter.Statistics();
            }
        }

    }
}
