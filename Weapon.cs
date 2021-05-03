using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Weapon : Item
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(string name, float weight, int buyPrice, int sellPrice, int minimumDamage, int maximumDamage) : base(name, weight, buyPrice, sellPrice)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
}
