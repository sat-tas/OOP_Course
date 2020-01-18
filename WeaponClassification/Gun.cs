using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponClassification
{
    public class Gun : AbstractWeapon
    {
        private int capacity;
        private double calibre;

        public int Capacity
        {
            get => capacity;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be negative");
                capacity = value;
            }
        }

        public double Calibre
        {
            get => calibre;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be negative");
                calibre = value;
            }
        }

        public Gun(string name, string type, double weight, int capacity, double calibre) : base(name, type, weight)
        {
            Capacity = capacity;
            Calibre = calibre;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nCapacity - {Capacity}\nCalibre - {Calibre}";
        }
    }
}
