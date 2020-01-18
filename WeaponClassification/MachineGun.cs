using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponClassification
{
    public class MachineGun : Gun
    {
        private string platform;
        private double breakingThrough;
        private int rateOfFire;

        public string Platform
        {
            get => platform;
            set
            {
                platform = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        
        public double BreakingThrough
        {
            get => breakingThrough;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be negative");
                breakingThrough = value;
            }
        }

        public int RateOfFire
        {
            get => rateOfFire;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be negative");
                rateOfFire = value;
            }
        }


        public MachineGun(string name, string type, double weight, int capacity, double calibre, string platform, double breakingThrough, int rateOfFire) : base(name, type, weight, capacity, calibre)
        {
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            BreakingThrough = breakingThrough;
            RateOfFire = rateOfFire;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nPlatform - {Platform}\nBreakingThrough - {BreakingThrough}\nRateOfFire - {RateOfFire}";
        }
    }
}
