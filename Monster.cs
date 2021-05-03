using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Monster : ILivingCreature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardGold { get; set; }
        public int CurrentHitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaximumHitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Monster(int id, string name, int maximumDamage, int rewardGold, int currentHitPoints, int maximumHitPoints)
            //: base(currentHitPoints, maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            
            RewardGold = rewardGold;
        }
    }
}
