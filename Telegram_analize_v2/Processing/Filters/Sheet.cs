using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_analize_v2.Processing
{
    class Sheet
    {
        public int Number { get; set; }
        public double Lenght { get; set; }
        public double Offset { get; set; }
        public int Coil_ID { get; set; }
        public int Packet_ID { get; set; }

        public Sheet(int coil_ID, int packet_ID, int number, double lenght, double offset)
        {
            Number = number;
            Lenght = lenght;
            Offset = offset;
            Coil_ID = coil_ID;
            Packet_ID = packet_ID;
        }

        public override bool Equals(object obj)
        {
            return obj is Sheet sheet &&
                   Number == sheet.Number &&
                   Coil_ID == sheet.Coil_ID;
        }

        public override int GetHashCode()
        {
            int hashCode = -28474310;
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            hashCode = hashCode * -1521134295 + Coil_ID.GetHashCode();
            return hashCode;
        }
    }
}
