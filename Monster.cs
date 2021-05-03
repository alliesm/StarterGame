using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Monster : LivingCreature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardGold { get; set; }
        public int MaximumHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        public Monster(int id, string name, int maximumDamage, int rewardGold, int currentHitPoints, int maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = currentHitPoints;
            RewardGold = rewardGold;
        }
    }
}
