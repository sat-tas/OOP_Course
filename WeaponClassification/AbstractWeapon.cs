using System;

namespace WeaponClassification
{
    public abstract class AbstractWeapon
    {
        private string name;
        private string type;
        private double weight;

        public double Weight { get => weight; set => weight = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }

        public AbstractWeapon(string name, string type, double weight)
        {
            this.name = name;
            this.type = type;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"Name - {name}\nType - {type}\nWeight - {weight}";
        }
    }
}
