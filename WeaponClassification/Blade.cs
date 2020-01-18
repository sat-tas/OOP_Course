using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponClassification
{
    public class Blade : AbstractWeapon
    {
        private double length;
        private int countHand;

        public double Length
        {
            get => length;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be negative");
                length = value;
            }
        }
        public int CountHand
        {
            get => countHand;
            set
            {
                if (value < 0 || value > 2)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} not in [1;2]");
                else
                    countHand = value;
            }
        }

        public Blade(double length, int countHand, string name, string type, double weight) : base(name, type, weight)
        {
            Length = length;
            CountHand = countHand;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nLength - {Length}\nCountHand - {CountHand}";
        }
    }
}
