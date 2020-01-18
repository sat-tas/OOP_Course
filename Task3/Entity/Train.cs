using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Entity
{
    public class Train
    {
        private string ost;
        private int number;
        private TimeSpan time;

        public string Ost
        {
            get => ost;
            set
            {
                ost = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public int Number
        {
            get => number;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} can't be negative");
                number = value;
            }
        }
        public TimeSpan Time { get => time; set => time = value; }

        public Train(string ost, int number, TimeSpan time)
        {
            Ost = ost;
            Number = number;
            Time = time;
        }

        public override string ToString()
        {
            return $"Поезд {number} отправляется в {ost}. Время отправления {time}";
        }
    }
}
